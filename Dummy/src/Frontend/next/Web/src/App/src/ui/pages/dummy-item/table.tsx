import { DeleteDummyItemButton, UpdateDummyItemButton } from '@/ui/pages/dummy-item/buttons';
import { DummyItemGetListActionQuery } from '@/lib';
import serverContext from '@/lib/serverContext';
import Pagination from '@/ui/components/pagination';
import { serverActionToDummyItemGetList } from '@/lib/serverActions';

export default async function Table({ query, pageSize }: { query: DummyItemGetListActionQuery, pageSize: number }) {
  const t = await serverContext.app.localization.getTranslator();

  //await new Promise((resolve) => setTimeout(resolve, 5000));
  const { items, totalCount } = await serverActionToDummyItemGetList(query);

  const totalPages = Math.ceil(totalCount / pageSize);

  return (
    <>
      <div className="mt-6 flow-root">
        <div className="inline-block min-w-full align-middle">
          <div className="rounded-lg bg-gray-50 p-2 md:pt-0">
            <div className="md:hidden">
              {items?.map((item) => (
                <div key={item.id} className="mb-2 w-full rounded-md bg-white p-4">
                  <div className="flex items-center justify-between border-b pb-4">
                    <div className="mb-2 flex items-center gap-2">
                      <p>{item.id}</p>
                      <p>{item.name}</p>
                    </div>
                  </div>
                  <div className="flex w-full items-center justify-between pt-4">
                    <div className="flex justify-end gap-2">
                      <UpdateDummyItemButton id={item.id} />
                      <DeleteDummyItemButton id={item.id} />
                    </div>
                  </div>
                </div>
              ))}
            </div>
            <table className="hidden min-w-full text-gray-900 md:table">
              <thead className="rounded-lg text-left text-sm font-normal">
                <tr>
                  <th scope="col" className="px-4 py-5 font-medium sm:pl-6 w-20">
                    {t('ui.pages.dummy-item._table.column.id.Title')}
                  </th>
                  <th scope="col" className="px-3 py-5 font-medium">
                    {t('ui.pages.dummy-item._table.column.name.Title')}
                  </th>
                  <th scope="col" className="relative py-3 pl-6 pr-3">
                    <span className="sr-only">{t('ui.pages.dummy-item._table.column.actions.Title')}</span>
                  </th>
                </tr>
              </thead>
              <tbody className="bg-white">
                {items?.map((item) => (
                  <tr key={item.id} className="w-full border-b py-3 text-sm last-of-type:border-none [&:first-child>td:first-child]:rounded-tl-lg [&:first-child>td:last-child]:rounded-tr-lg [&:last-child>td:first-child]:rounded-bl-lg [&:last-child>td:last-child]:rounded-br-lg">
                    <td className="whitespace-nowrap px-3 py-3">
                      {item.id}
                    </td>
                    <td className="whitespace-nowrap py-3 pl-6 pr-3">
                      <div className="flex items-center gap-3">
                        <p>{item.name}</p>
                      </div>
                    </td>
                    <td className="whitespace-nowrap py-3 pl-6 pr-3">
                      <div className="flex justify-end gap-3">
                        <UpdateDummyItemButton id={item.id} />
                        <DeleteDummyItemButton id={item.id} />
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div className="mt-5 flex w-full justify-center">
        <Pagination totalPages={totalPages} />
      </div>
    </>
  );
}
