using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class CreateBlogToBlogPost : BaseBinder<Blog.Entry, BlogPost>
    {
        public override void Load(Blog.Entry source, BlogPost dest)
        {
            dest.Title = source.Title;
            dest.FullText = source.FullText;
            dest.CreationDate = source.CreatedDate;
            dest.ModifyDate = source.CreatedDate;
            dest.Id = source.Id;
        }

        public override void InverseLoad(BlogPost source, Blog.Entry dest)
        {
            source.Title = dest.Title;
            source.FullText = dest.FullText;
            source.CreationDate = dest.CreatedDate;
            source.Id = dest.Id;
        }
    }
}