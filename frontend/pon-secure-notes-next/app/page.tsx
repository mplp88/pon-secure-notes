import Link from 'next/link';
import { Shield, Lock, Key } from 'lucide-react';

export const dynamic = 'force-dynamic';

export default function Home() {
  return (
    <main className="min-h-[calc(100vh-4rem)]">
      <div className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
        <div className="flex flex-col items-center justify-center py-20 text-center">
          <div className="mb-8 inline-flex h-20 w-20 items-center justify-center rounded-full bg-primary/10">
            <Lock className="h-10 w-10 text-primary" />
          </div>
          <h1 className="mb-4 text-5xl font-bold tracking-tight text-balance">
            Secure Notes
          </h1>
          <p className="mb-8 max-w-2xl text-lg text-muted-foreground text-balance">
            Aplicación de notas seguras con encriptación de extremo a extremo.
            Protege tu información personal con la mejor tecnología de
            seguridad.
          </p>
          <div className="flex gap-4">
            <Link
              href="/register"
              className="rounded-md bg-primary px-6 py-3 font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
            >
              Get Started
            </Link>
            <Link
              href="/about"
              className="rounded-md border border-border bg-card px-6 py-3 font-medium text-card-foreground hover:bg-secondary transition-colors"
            >
              Learn More
            </Link>
          </div>
        </div>

        <div className="grid gap-6 pb-20 md:grid-cols-3">
          <div className="rounded-lg border border-border bg-card p-6">
            <div className="mb-4 inline-flex h-12 w-12 items-center justify-center rounded-lg bg-primary/10">
              <Shield className="h-6 w-6 text-primary" />
            </div>
            <h3 className="mb-2 text-lg font-semibold">
              End-to-End Encryption
            </h3>
            <p className="text-sm text-muted-foreground">
              Tus notas están protegidas con encriptación de nivel militar
            </p>
          </div>
          <div className="rounded-lg border border-border bg-card p-6">
            <div className="mb-4 inline-flex h-12 w-12 items-center justify-center rounded-lg bg-primary/10">
              <Lock className="h-6 w-6 text-primary" />
            </div>
            <h3 className="mb-2 text-lg font-semibold">Secure Storage</h3>
            <p className="text-sm text-muted-foreground">
              Almacenamiento seguro en la nube con protección avanzada
            </p>
          </div>
          <div className="rounded-lg border border-border bg-card p-6">
            <div className="mb-4 inline-flex h-12 w-12 items-center justify-center rounded-lg bg-primary/10">
              <Key className="h-6 w-6 text-primary" />
            </div>
            <h3 className="mb-2 text-lg font-semibold">Privacy First</h3>
            <p className="text-sm text-muted-foreground">
              Tu privacidad es nuestra prioridad número uno
            </p>
          </div>
        </div>
      </div>
    </main>
  );
}

