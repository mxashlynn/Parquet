using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetRunner
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var region = new MapRegion();
            Console.WriteLine(region);

            // TODO: Considering developing the Class Library and Unity project side-by-side.

            // DLL-based soluion:                                           <-- This is probably the solution we want.
            // https://docs.unity3d.com/Manual/UsingDLL.html
            // https://loekvandenouweland.com/content/create-a-class-library-with-unity3d-and-visual-studio.html

            // Submodule-based solution:                                    <-- This is the solution Ashley reccomends.
            // https://git-scm.com/book/en/v2/Git-Tools-Submodules
            // https://github.blog/2016-02-01-working-with-submodules/
            // https://stackoverflow.com/questions/36554810/how-to-link-folder-from-a-git-repo-to-another-repo
            // https://stackoverflow.com/questions/1116465/how-do-you-share-code-between-projects-solutions-in-visual-studio

            // Hardlink-based or Symlink-based solution:                    <-- This is the solution Alex used.
            // https://codingkilledthecat.wordpress.com/tag/git/
            // https://www.reddit.com/r/git/comments/8r4sen/preserve_hardlinks_in_git/
            // https://stackoverflow.com/questions/3729278/git-and-hard-links
            // https://stackoverflow.com/questions/1116465/how-do-you-share-code-between-projects-solutions-in-visual-studio
            // https://www.howtogeek.com/howto/16226/complete-guide-to-symbolic-links-symlinks-on-windows-or-linux/
        }
    }
}
