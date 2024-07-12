using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    public class FemalyMembers
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public FemalyMembers Husband { get; set; }
        public FemalyMembers Wife { get; set; }
        public string FullName { get; set; }
        public FemalyMembers Mother { get; set; }
        public FemalyMembers Father { get; set; }
        public FemalyMembers? Partner { get; private set; }
        public FemalyMembers? Parent1 { get; private set; }
        public FemalyMembers? Parent2 { get; private set; }
        public FemalyMembers? Children { get; private set; }

    public FemalyMembers[] GetGrandMother()
        {
            return new FemalyMembers[] { Mother?.Mother, Father?.Mother };
        }

        public FemalyMembers[] GetGrandFather()
        {
            return new FemalyMembers[] { Mother?.Father, Father?.Father };
        }
        public FemalyMembers[] GetParent()
        {
            return new FemalyMembers[] { Mother, Father };
        }    
        public void SetPartner(FemalyMembers partner)
        {
            if (Partner != null) Partner.Partner = null;
            partner.Partner = this;
            Partner = partner;
        }
        public void SetChildren (FemalyMembers children)
        {
            if (children != null) children.Children = null;
            children.Children = this;
            Children = children;
        }

    }


    public enum Gender { men, woman }


}
