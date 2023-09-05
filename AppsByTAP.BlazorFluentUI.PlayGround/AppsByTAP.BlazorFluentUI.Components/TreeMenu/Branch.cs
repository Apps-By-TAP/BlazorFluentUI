using System;
using System.Collections.Generic;

namespace AppsByTAP.BlazorFluentUI.Components.TreeMenu
{
    public class Branch<T>
    {
        public string ID { get; private set; }
        public T RootItem { get; set; }
        public bool IsExpandable { get; set; }
        public List<BranchItem<T>> Items { get; set; }
        public Branch<T> Parent { get; set; }

        public Branch()
        {
            ID = Guid.NewGuid().ToString();
        }

        public Branch(T rootItem, bool isExpandable, List<BranchItem<T>> items, Branch<T> parent)
        {
            ID = Guid.NewGuid().ToString();
            RootItem = rootItem;
            IsExpandable = isExpandable;
            Items = items;
            Parent = parent;
        }

        public override string ToString()
        {
            return RootItem.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Branch<T> branch)
            {
                return ID == branch.ID;
            }

            return false;
        }
    }

    public class BranchItem<T>
    {
        public T RootItem { get; set; }
        public bool IsExpandable { get; set; }

        public BranchItem(){}

        public BranchItem(T rootItem, bool isExpandable)
        {
            RootItem = rootItem;
            IsExpandable = isExpandable;
        }

        public override string ToString()
        {
            return RootItem.ToString();
        }
    }
}
