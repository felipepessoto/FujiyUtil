using System;
using System.Collections;
using System.Collections.Generic;

namespace Fujiy.Util.Collections.Generic
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1035:ICollectionImplementationsHaveStronglyTypedMembers", Justification = "A classe é apenas um wrapper para ser usado com DataPager. Não implementa os métodos do ICollection")]
    public sealed class PagedCollection<T> : IEnumerable<T>, ICollection
    {
        private IEnumerable<T> ActualPage { get; set; }
        private int Total { get; set; }
        private int StartIndex { get; set; }

        public PagedCollection(int totalItems, int startIndex, IEnumerable<T> actualPage)
        {
            ActualPage = actualPage;
            Total = totalItems;
            StartIndex = startIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            bool afterPage = false;
            for (int i = 0; i < Total; i++)
            {
                if (i < StartIndex || afterPage)
                {
                    yield return default(T);
                }
                else
                {
                    afterPage = true;
                    foreach (T itempagina in ActualPage)
                    {
                        i++;
                        yield return itempagina;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Implementation of ICollection

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotSupportedException();
        }

        public int Count
        {
            get { return Total; }
        }

        object ICollection.SyncRoot
        {
            get { throw new NotSupportedException(); }
        }

        bool ICollection.IsSynchronized
        {
            get { throw new NotSupportedException(); }
        }

        #endregion
    }
}
