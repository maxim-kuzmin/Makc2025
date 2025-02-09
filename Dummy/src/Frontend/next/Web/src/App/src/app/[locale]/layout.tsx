import '@/ui/globals.css';
import { inter } from '@/ui/fonts';
import serverContext from '@/lib/serverContext';
import ClientContextWrapper from '@/ui/components/client-context-wrapper';

export async function generateMetadata() {
  const t = await serverContext.app.localization.getTranslator();

  const description = t('app._layout.Description');
  const title = t('app._layout.Title');

  return {
    title: {
      template: `%s | ${title}`,
      default: title,
    },
    description,
  }
}

export default function RootLayout({
    params: { locale },
    children 
  }: {
    params: { locale: string },
    children: React.ReactNode 
  }) {
    const params = {locale};
  return (
    <html lang={locale}>
      <body className={`${inter.className} antialiased`}>
        <ClientContextWrapper params={params}>
          {children}
        </ClientContextWrapper>
        </body>
    </html>
  );
}