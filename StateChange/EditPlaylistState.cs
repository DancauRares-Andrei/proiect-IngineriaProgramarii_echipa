using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StateChange
{
    public class EditPlaylistState : IState
    {
        public bool Handle(Context context)
        {
            // Verificăm dacă starea actuală este deja EditPlaylistState
            if (context.StateNumber == MP3PlayerStates.EditPlaylistState)
            {
                // Dacă da, eliminăm controalele existente și adăugăm cele necesare pentru această stare
                context.Controls.Clear();
                context.Controls.Add(new AxWindowsMediaPlayer());
                context.Controls.Add(new ListBox());
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());
                context.Controls.Add(new Button());

                return true; // Returnăm true pentru a indica că starea este valida
            }
            // Dacă nu suntem în starea RadioState, trecem la altă stare
            switch (context.StateNumber)
            {
                case MP3PlayerStates.PlaylistState: context.State = new PlaylistState(); break;
                case MP3PlayerStates.MakePlaylistState: context.State = new MakePlaylistState(); break;
                case MP3PlayerStates.RadioState: context.State = new RadioState(); break;
                case MP3PlayerStates.SingleFileState: context.State = new SingleFileState(); break;

            }
            return false;
        }
    }
}
