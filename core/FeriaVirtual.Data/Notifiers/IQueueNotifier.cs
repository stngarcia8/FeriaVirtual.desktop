// /*******************************************************
// * Author: Daniel García Asathor
// *******************************************************/

namespace FeriaVirtual.Data.Notifiers{

    public interface IQueueNotifier{

        void Notify(string publishingGroup, string eventToPost, object objectToPublish);

    }

}