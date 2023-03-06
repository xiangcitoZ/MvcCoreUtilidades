namespace MvcCoreUtilidades.Helpers
{
    public class HelperUploadFiles
    {
        private HelperPathProvider helperPath;
        
        public HelperUploadFiles(HelperPathProvider pathProvider) 
        {
            this.helperPath = pathProvider;
        
        }

        public async Task<string> UploadFileAsync(IFormFile file, Folders folder)
        {
            string fileName = file.Name;
            string path =
                this.helperPath.MapPath(fileName,folder);
            using (Stream stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;


        }



    }
}
