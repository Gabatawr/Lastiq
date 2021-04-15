using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using SticksyProtocol;

namespace SticksyClient
{
    public class Client {
        public Listener Listener { get; }
        public Sender Sender { get; }
        public User User { get; }

        public Client(TcpClient tcpClient)
        {
            Listener = new Listener(tcpClient, User);
            Sender = new Sender(tcpClient, User);
        }
    }

    public class Sender
    { 
        private TcpClient socket;
        private User User { get; }
        public Sender(TcpClient tcpClient, User user)
        {
            socket = tcpClient;
            User = user;
        }

        //регистрация
        public void SignUp(string login, string password)
        {
            Transfer.SendData(socket, new Sign(login, password, CommandUser.SignUp));
        }
        //авторизация
        public void SignIn(string login, string password)
        {
            Transfer.SendData(socket, new Sign(login, password, CommandUser.SignIn));
        }

        public void CreateSticker()
        {
            Transfer.SendData(socket, new CreateStick(User.id));
        }

        public void DeleteSticker(int indexSticker)
        {
            Transfer.SendData(socket, new DelStick(indexSticker + 1));
            User.sticks.Remove(User.sticks.Find(st => st.id == indexSticker + 1));
        }

        public void GetUsers()
        {
            Transfer.SendData(socket, new GetUsers());
        }

        //public void AddFriend(int idFriend, int idStick)
        //{
        //    Transfer.SendData(socket, new AddFriend(User.id, idFriend, idStick));
        //}

        public void EditTitle(int indexSticker, string title)
        {
            Stick stick = User.sticks[indexSticker];
            if (stick.title != title)
            {
                stick.title = title;
                SaveSticker(stick);
            }
        }

        //public void EditContentText(int indexSticker, int indexContent, string text)
        //{
        //    TextCheck content = User.sticks[indexSticker].content[indexContent];
        //    if (content.text != text)
        //    {
        //        content.text = text;
        //        SaveSticker(User.sticks[indexSticker]);
        //    }
        //}

        //public void EditContentIsChecked(int indexSticker, int indexContent, bool isChecked)
        //{
        //    TextCheck content = User.sticks[indexSticker].content[indexContent];
        //    if (content.isChecked != isChecked)
        //    {
        //        content.isChecked = isChecked;
        //        SaveSticker(User.sticks[indexSticker]);
        //    }
        //}

        public void EditTag(int indexSticker, int indexTag, string tag)
        {
            Stick stick = User.sticks[indexSticker];
            if (stick.tags[indexTag] != tag)
            {
                stick.tags[indexTag] = tag;
                SaveSticker(stick);
            }
        }

        public void EditTags(int indexSticker, List<string> tags)
        {
            Stick stick = User.sticks[indexSticker];
            if (stick.tags.Except(tags).Count() != 0)
            {
                stick.tags = tags;
                SaveSticker(stick);
            }
        }

        public void EditDate(int indexSticker, DateTime date)
        {
            Stick stick = User.sticks[indexSticker];
            if (stick.date != date)
            {
                stick.date = date;
                SaveSticker(stick);
            }
        }

        public void EditColor(int indexSticker, string color)
        {
            Stick stick = User.sticks[indexSticker];
            if (stick.color != color)
            {
                stick.color = color;
                SaveSticker(stick);
            }
        }

        public void SaveSticker(Stick stick, int index = -1)
        {
            if (index >= 0)
            {
                User.sticks[index] = stick;
            }
            Transfer.SendData(socket, new EditStick(stick));
        }
    }

    //создается только в клиенте
    public class Listener
    {
        private TcpClient socket;
        private User User;

        public delegate void SignUpD(AnswerId answerId);
        public event SignUpD SigningUp;

        public delegate void SignInD(AnswerUser answerUser);
        public event SignInD SigningIn;

        public delegate void CreateStickerD(AnswerId answerId);
        public event CreateStickerD CreatingSticker;

        public delegate void ReceiveListUsersD(AnswerListUser answerList);
        public event ReceiveListUsersD ReceivingListUsers;

        public delegate void EditStickerD(EditStick editStick);
        public event EditStickerD EditingSticker;

        public Listener(TcpClient tcpClient, User user)
        {
            socket = tcpClient;
            User = user;
            ListenAsync();
        }

        //метод для обработчика события SigningUp, true - если зарегистрировались
        public bool SignUpForHandler(AnswerId answerId, string login, string password)
        {
            if (answerId.id == -1) return false;
            User = new User(answerId.id, login);
            return true;
        }

        //метод для обработчика события SigningIn, true - если вошли
        public bool SignInForHandler(AnswerUser answerUser)
        {
            User = answerUser.user;
            return User != null;
        }

        //метод для обработчика события CreatingSticker
        public Stick СreatingStickerForHander(AnswerId answerId)
        {
            Stick stick = new Stick(answerId.id, User.id);
            User.sticks.Add(stick);
            return stick;
        }

        //метод для обработчика события ReceivingListUsers
        public List<Friend> ReceiveUsersForHandler(AnswerListUser answerList)
        {
            return answerList.users;
        }

        //метод для обработчика события EditingSticker
        public void EditingStickForHandler(EditStick editStick)
        {
            Stick stick = User.sticks.Find(st => st.id == editStick.stick.id);
            stick = editStick.stick;
        }

        public async void ListenAsync()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    IData data = Transfer.ReceiveData(socket);
                    if (data is AnswerId && ((AnswerId)data).typeId == TypeId.IdUser) // Sing Up                ///////////////
                    {
                        if (SigningUp != null) SigningUp((AnswerId)data);
                    }
                    else if (data is AnswerUser) //Sign In
                    {
                        if (SigningIn != null) SigningIn((AnswerUser)data);
                    }
                    else if (data is AnswerId && ((AnswerId)data).typeId == TypeId.IdStick) //Create Sticker     ///////////////
                    {
                        if (CreatingSticker != null) CreatingSticker((AnswerId)data);
                    }
                    else if (data is AnswerListUser) // Get Users
                    {
                        if (ReceivingListUsers != null) ReceivingListUsers((AnswerListUser)data);
                    }
                    else if (data is EditStick) //Add Friend, Edit Stick
                    {
                        if (EditingSticker != null) EditingSticker((EditStick)data);
                    }
                }
            });
        }
    }
}