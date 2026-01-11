'use client';

import type React from 'react';
import { useEffect, useState } from 'react';
import { type AuthState, useAuthStore } from '@/stores/auth.store';
import { useRouter } from 'next/navigation';
import { Plus, Trash2, Shield, ShieldOff } from 'lucide-react';

interface Note {
  id: string;
  title: string;
  content: string;
  isEncrypted: boolean;
}

export default function NotesPage() {
  const token = useAuthStore((state: AuthState) => state.token);
  const router = useRouter();

  const [notes, setNotes] = useState<Note[]>([]);
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');
  const [encrypt, setEncrypt] = useState(true);
  const [loading, setLoading] = useState(true);

  const getNotes = async () => {
    try {
      const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/notes`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      const data = await res.json();
      setNotes(data);
    } catch (err) {
      console.error('Failed to fetch notes:', err);
    }
  };

  const createNote = async (e: React.FormEvent) => {
    try {
      e.preventDefault();
      const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/notes`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({ title, content, encrypt }),
      });
      if (!res.ok) throw new Error('Failed to create note');

      setTitle('');
      setContent('');

      await getNotes();
    } catch (err) {
      console.error('Error creating note:', err);
    }
  };

  const deleteNote = async (id: string) => {
    const deleteNote = confirm(
      'Are you sure you want to delete this note? This action cannot be undone.'
    );

    if (!deleteNote) return;

    const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/notes/${id}`, {
      method: 'DELETE',
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    const data = await res.json();
    if (!data.ok) {
      console.error('Failed to delete note');
      return;
    }

    await getNotes();
  };

  useEffect(() => {
    if (!token) {
      router.push('/login');
      return;
    }

    fetch(`${process.env.NEXT_PUBLIC_API_URL}/notes`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => res.json())
      .then((data) => {
        setNotes(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error('Failed to fetch notes:', err);
      });
  }, [token, router]);

  return (
    <main className="min-h-[calc(100vh-4rem)]">
      <div className="mx-auto max-w-7xl px-4 py-8 sm:px-6 lg:px-8">
        <div className="mb-8">
          <h1 className="text-3xl font-bold tracking-tight">Your Notes</h1>
          <p className="mt-2 text-sm text-muted-foreground">
            Create and manage your encrypted notes securely
          </p>
        </div>

        <div className="mb-8 rounded-lg border border-border bg-card p-6">
          <h2 className="mb-4 text-lg font-semibold">Create New Note</h2>
          <form onSubmit={(e) => createNote(e)} className="space-y-4">
            <div>
              <label htmlFor="title" className="mb-2 block text-sm font-medium">
                Title
              </label>
              <input
                id="title"
                type="text"
                placeholder="Enter note title"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                required
                className="w-full rounded-md border border-input bg-background px-4 py-2 text-sm placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring"
              />
            </div>
            <div>
              <label
                htmlFor="content"
                className="mb-2 block text-sm font-medium"
              >
                Content
              </label>
              <textarea
                id="content"
                placeholder="Enter note content"
                value={content}
                onChange={(e) => setContent(e.target.value)}
                required
                rows={4}
                className="w-full rounded-md border border-input bg-background px-4 py-2 text-sm placeholder:text-muted-foreground focus:border-ring focus:outline-none focus:ring-1 focus:ring-ring resize-none"
              />
            </div>
            <div className="flex items-center justify-between">
              <label className="flex items-center gap-2 text-sm">
                <input
                  type="checkbox"
                  checked={encrypt}
                  onChange={(e) => setEncrypt(e.target.checked)}
                  className="h-4 w-4 rounded border-input text-primary focus:ring-2 focus:ring-ring focus:ring-offset-2 focus:ring-offset-background"
                />
                <span className="font-medium">Encrypt this note</span>
              </label>
              <button
                type="submit"
                className="inline-flex items-center gap-2 rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
              >
                <Plus className="h-4 w-4" />
                Create Note
              </button>
            </div>
          </form>
        </div>

        {loading ? (
          <div className="flex items-center justify-center py-12">
            <p className="text-muted-foreground">Loading notes...</p>
          </div>
        ) : notes.length === 0 ? (
          <div className="rounded-lg border border-dashed border-border bg-card p-12 text-center">
            <p className="text-muted-foreground">
              No notes yet. Create your first note above.
            </p>
          </div>
        ) : (
          <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
            {notes.map((note) => (
              <div
                key={note.id}
                className="rounded-lg border border-border bg-card p-6 transition-shadow hover:shadow-lg"
              >
                <div className="mb-3 flex items-start justify-between">
                  <h3 className="font-semibold text-lg">{note.title}</h3>
                  <div className="flex items-center gap-2">
                    {note.isEncrypted ? (
                      <Shield
                        className="h-4 w-4 text-primary"
                        title="Encrypted"
                      />
                    ) : (
                      <ShieldOff
                        className="h-4 w-4 text-muted-foreground"
                        title="Not encrypted"
                      />
                    )}
                    <button
                      onClick={() => deleteNote(note.id)}
                      className="rounded p-1 text-muted-foreground hover:bg-destructive/10 hover:text-destructive transition-colors"
                      title="Delete note"
                    >
                      <Trash2 className="h-4 w-4" />
                    </button>
                  </div>
                </div>
                <p className="text-sm text-muted-foreground line-clamp-3">
                  {note.content}
                </p>
              </div>
            ))}
          </div>
        )}
      </div>
    </main>
  );
}

