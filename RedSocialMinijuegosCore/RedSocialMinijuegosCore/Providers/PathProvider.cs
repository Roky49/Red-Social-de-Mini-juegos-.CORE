using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Providers
{
    public enum Folders
    {
        Uploads = 0, Documents = 1, Images = 2
    }
    public class PathProvider
    {
            IHostingEnvironment environment;

            public PathProvider(IHostingEnvironment environment)
            {
                this.environment = environment;
            }

            public String MapPath(String filename, Folders folder)
            {
                String foldername;
                switch (folder)
                {
                    case Folders.Documents:
                        foldername = "documents";
                        break;
                    case Folders.Images:
                        foldername = "img/Carrusel";
                        break;
                    default:
                        foldername = "uploads";
                        break;
                }
                String path =
                    Path.Combine(this.environment.WebRootPath, foldername, filename);
                return path;
            }
        
    }
}
