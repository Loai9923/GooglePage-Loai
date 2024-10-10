using Core.Dtos;
using Core.Entites;
using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleWebService.GoogleServices
{
    public class GoogleService : IPosted
    {
      public static  List<Posted> _post;
        public GoogleService() 
        {
            if (_post is null) 
            {
                _post = new List<Posted>();
                _post.Add(new Posted() 
                {
                    Title= "Pioneers",
                   
                     Contatns= "Pioneers Academy is an internationally accredited academy providing more than 300 in demand courses to master the skills companies need."
                });
                _post.Add(new Posted()
                {
                    Title = "Pioneers",

                    Contatns = "Pioneers Academy is an internationally accredited academy providing more than 300 in demand courses to master the skills companies need."
                });
                _post.Add(new Posted()
                {
                    Title = "Pioneers",

                    Contatns = "Pioneers Academy is an internationally accredited academy providing more than 300 in demand courses to master the skills companies need."
                });

                _post.Add(new Posted()
                {
                    Title = "title",

                    Contatns = " Erin accidentally created a new universe."
                });
                _post.Add(new Posted()
                {
                    Title = "title",

                    Contatns = " I've always wanted to go to Tajikistan, but my cat would miss me"
                });
                _post.Add(new Posted()
                {
                    Title = "title",

                    Contatns = " There are few things better in life than a slice of pie"
                });
                _post.Add(new Posted()
                {
                    Title = "title2",

                    Contatns = " The fish listened intently to what the frogs had to say"
                });
                _post.Add(new Posted()
                {
                    Title = "title2",

                    Contatns = " Mr. Montoya knows the way to the bakery even though he's never been there"
                });
                _post.Add(new Posted()
                {
                    Title = "title2",

                    Contatns = " Thirty years later, she still thought it was okay to put the toilet paper roll under rather than over"
                });
                _post.Add(new Posted()
                {
                    Title = "title2",

                    Contatns = " If I don’t like something, I’ll stay away from ite"
                });
                _post.Add(new Posted()
                {
                    Title = "title2",

                    Contatns = " The waitress was not amused when he ordered green eggs and ham"
                });
            }

        }
        /// <summary>
        /// Add the Content wich you Need
        /// </summary>
        /// <param name="posted"></param>
        /// <returns></returns>
        public OpStatus Add(Posted posted)
        {
            try
            {
                var Exist = _post.Any(q => q.Title == posted.Title);
                if (!Exist)
                {
                    _post.Add(posted);
                    return OpStatus.Success;
                }
                else
                {
                    return OpStatus.error;
                }
            }
            catch
            {
                return OpStatus.error;

            }
        }

        /// <summary>
        /// delete the Selected Content
        /// </summary>
        /// <param name="posted"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public OpStatus Delete(Posted posted)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// return Spacific Content 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Posted> GetPosts(PostedDto title)
        {
            try 
            { 
                var Allpost = _post.Where(q => q.Title == title.Title).ToList();
                if (Allpost != null)
                {
                    return Allpost;
                }
                else if (title.Title == null)
                {
                    return null;
                }
                else
                    return null;
            }
            catch 
            {
                throw;
            }
        }

       

        public OpStatus Update(Posted posted)
        {
            throw new NotImplementedException();
        }
    }
}
