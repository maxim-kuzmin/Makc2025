import { Suspense } from 'react';
import { CreateDummyItemButton } from '@/ui/pages/dummy-item/buttons';
import { lusitana } from '@/ui/fonts';
import serverContext from '@/lib/serverContext';
import { createDummyItemGetListActionQuery } from '@/lib';
import Search from '@/ui/components/search';
import Table from '@/ui/pages/dummy-item/table';
import TableSkeleton from '@/ui/pages/dummy-item/table-skeleton';

export async function generateMetadata() {
  const t = await serverContext.app.localization.getTranslator();

  return {
    title: t('app.dummy-item._page.Title'),
  }
}

const pageSize = 10;

export default async function Page({
  searchParams,
}: {
  searchParams?: {
    query?: string;
    page?: string;
  };
}) {
  const t = await serverContext.app.localization.getTranslator();

  const fullTextSearchQuery = searchParams?.query || '';
  const currentPage = Number(searchParams?.page) || 1;

  const query = createDummyItemGetListActionQuery({
    filter: {
      fullTextSearchQuery
    },
    page: {
      size: pageSize,
      number: currentPage
    }
  });

  return (
    <div className="w-full">
      <div className="flex w-full items-center justify-between">
        <h1 className={`${lusitana.className} text-2xl`}>{t('app.dummy-item._page.Title')}</h1>
      </div>
      <div className="mt-4 flex items-center justify-between gap-2 md:mt-8">
        <Search placeholder={t('app.dummy-item._page.search.Placeholder')} />
        <CreateDummyItemButton />
      </div>
      <Suspense key={fullTextSearchQuery + currentPage} fallback={<TableSkeleton pageSize={pageSize} />}>
        <Table query={query} pageSize={pageSize} />
      </Suspense>
    </div>
  );
}