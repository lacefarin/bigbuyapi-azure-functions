using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.Pagination
{
    public class PaginationService<T>
    {
        public async Task<List<T>> FetchUntilEmptyResult(int parentTaxonomy, Func<int, int, int, Task<List<T>?>> getResult, int taskBatchSize = 5, int pageSize = 1000)
        {
            ConcurrentBag<T> allValues = new ConcurrentBag<T>();
            int currentPage = -1;

            while (true) 
            { 
                ConcurrentBag<T> values = new ConcurrentBag<T>();

                await Parallel.ForEachAsync(Enumerable.Range(0, taskBatchSize), new ParallelOptions { MaxDegreeOfParallelism = taskBatchSize }, async (i, token) =>
                {
                    var pageToFetch = Interlocked.Increment(ref currentPage);
                    var result = await getResult(pageToFetch, pageSize, parentTaxonomy);
                    result.ForEach(x => values.Add(x));
                    result.ForEach(x => allValues.Add(x));
                });

                if (values.Count < pageSize * taskBatchSize)
                {
                    break;
                }
            }

            return allValues.ToList();
        }

        public async Task<List<T>> FetchUntilEmptyResult(string isoCode, Func<int, int, string, Task<List<T>?>> getResult, int taskBatchSize = 5, int pageSize = 1000)
        {
            ConcurrentBag<T> allValues = new ConcurrentBag<T>();
            int currentPage = -1;

            while (true)
            {
                ConcurrentBag<T> values = new ConcurrentBag<T>();

                await Parallel.ForEachAsync(Enumerable.Range(0, taskBatchSize), new ParallelOptions { MaxDegreeOfParallelism = taskBatchSize }, async (i, token) =>
                {
                    var pageToFetch = Interlocked.Increment(ref currentPage);
                    var result = await getResult(pageToFetch, pageSize, isoCode);
                    result.ForEach(x => values.Add(x));
                    result.ForEach(x => allValues.Add(x));
                });

                if (values.Count < pageSize * taskBatchSize)
                {
                    break;
                }
            }

            return allValues.ToList();
        }
    }


}
