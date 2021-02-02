using CodingChallenge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    public class DbInitializer
    {
        public static void Initialize(CodingChallengeContext context, IServiceProvider services)
        {
            context.Database.EnsureCreated();

            if (context.Post.Any())
            {
                //The database was already seeded
                return;
            }

            var post = new Post()
            {
                Id = new Guid("225F876B-7BF8-43C6-AEC4-8A0C91F83E88"),
                Title = "History and purpose of Lorem ipsum text",
                Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. </p>

<p>Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. <b>Curabitur sodales ligula in libero</b>. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. </p>

<p>Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. </p>

<p>Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Ut fringilla</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <b>Etiam ultrices</b>. Sed non quam. In vel mi sit amet augue congue elementum. <b>Vestibulum sapien</b>. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. <i>Nunc feugiat mi a tellus consequat imperdiet</i>. Curabitur sit amet mauris. </p>

<p>Morbi in dui quis est pulvinar ullamcorper. <i>Quisque volutpat condimentum velit</i>. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. <b>Morbi in dui quis est pulvinar ullamcorper</b>. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. Aenean laoreet. </p>

",
                Likes = 0
            };

            context.Post.Add(post);
            context.SaveChanges();
        }
    }
}
