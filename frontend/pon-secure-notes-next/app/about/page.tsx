import { Shield, Users, Code } from 'lucide-react';

export const dynamic = 'force-static';

export default function About() {
  return (
    <main className="min-h-[calc(100vh-4rem)]">
      <div className="mx-auto max-w-4xl px-4 py-16 sm:px-6 lg:px-8">
        <div className="mb-12 text-center">
          <h1 className="mb-4 text-4xl font-bold tracking-tight">
            About Secure Notes
          </h1>
          <p className="text-lg text-muted-foreground text-balance">
            PoC enfocada en seguridad, arquitectura limpia y buenas prácticas
            full stack
          </p>
        </div>

        <div className="space-y-8">
          <div className="rounded-lg border border-border bg-card p-8">
            <div className="mb-4 flex items-center gap-3">
              <div className="inline-flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                <Shield className="h-5 w-5 text-primary" />
              </div>
              <h2 className="text-2xl font-semibold">Security First</h2>
            </div>
            <p className="text-muted-foreground leading-relaxed">
              Nuestra aplicación implementa las mejores prácticas de seguridad,
              incluyendo encriptación de datos, autenticación segura y
              protección contra vulnerabilidades comunes.
            </p>
          </div>

          <div className="rounded-lg border border-border bg-card p-8">
            <div className="mb-4 flex items-center gap-3">
              <div className="inline-flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                <Code className="h-5 w-5 text-primary" />
              </div>
              <h2 className="text-2xl font-semibold">Clean Architecture</h2>
            </div>
            <p className="text-muted-foreground leading-relaxed">
              Construida con una arquitectura limpia y escalable, siguiendo
              principios SOLID y patrones de diseño modernos para garantizar
              mantenibilidad y extensibilidad.
            </p>
          </div>

          <div className="rounded-lg border border-border bg-card p-8">
            <div className="mb-4 flex items-center gap-3">
              <div className="inline-flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                <Users className="h-5 w-5 text-primary" />
              </div>
              <h2 className="text-2xl font-semibold">Best Practices</h2>
            </div>
            <p className="text-muted-foreground leading-relaxed">
              Desarrollada siguiendo las mejores prácticas de la industria,
              incluyendo testing, CI/CD, y metodologías ágiles para entregar
              software de calidad.
            </p>
          </div>
        </div>
      </div>
    </main>
  );
}

