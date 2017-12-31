using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DigiDigiStartOver
{
    public class Monster
    {
        //�����X�^�[�摜�̐錾
        public Texture2D Image;
        //�����X�^�[�摜�̍��W�̐錾
        public Vector2 position;
    }

    public class Font
    {
        //�t�H���g�̐錾
        public SpriteFont font;
        //�t�H���g�̐錾
        public Vector2 position;
    }



    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //�w�i�摜dark-tech-background�̐錾
        Texture2D darkTechBackground;

        //�L�[�{�[�h�̏�Ԃ�錾
        KeyboardState KeyboardState;

        //�n�b�N����1P�̃����X�^�[�N���X
        Monster hackmon1P = new Monster();

        //�t���[���̐錾
        int frame = 0;
        // �n�b�N����1P�̃R�}�ʒu�̐錾
        int hackmon1PFrame = 0;
        // �n�b�N����1P��HPBar�摜�̐錾
        Texture2D HPBarForHackmon1P;
        // �n�b�N����1P��HPGauge�摜�̐錾
        Texture2D HPGaugeForHackmon1P;
        // �n�b�N����1P�̃t�B�t�X���b�V���摜�̐錾
        Texture2D hackmon1PfifSlash;
        // �n�b�N����1P�̃t�B�t�X���b�V���摜���W�̐錾
        Vector2 hackmon1PfifSlashPosition;
        //�n�b�N�����PP��HP�̐錾
        int HPwidthForhackmon1P;

        //�����蔻�����肷�锒�����̐錾
        Texture2D ColliderChecker;


        //�n�b�N�����QP�̃����X�^�[�N���X
        Monster hackmon2P = new Monster();
        // �n�b�N����2P�̃R�}�ʒu�̐錾
        int hackmon2PFrame = 0;
        // �n�b�N����2P��HPBar�摜�̐錾
        Texture2D HPBarForHackmon2P;
        // �n�b�N����2P��HPGauge�摜�̐錾
        Texture2D HPGaugeForHackmon2P;
        //�n�b�N����2P��HP�̐錾
        int HPwidthForhackmon2P;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //�n�b�N����1P�̃X�^�[�g�ʒu�̏�����
            hackmon1P.position = new Vector2(20, 50);
            //�n�b�N�����PP��HP�̏�����
            HPwidthForhackmon1P = 250;


            //�n�b�N����2P�̃X�^�[�g�ʒu�̏�����
            hackmon2P.position = new Vector2(720, 50);
            //�n�b�N����2P��HP�̏�����
            HPwidthForhackmon2P = 250;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //�w�i�摜dark-tech-background�̃��[�h
            darkTechBackground = Content.Load<Texture2D>("dark-tech-background");
            //�n�b�N����1P�摜�̃��[�h
            hackmon1P.Image = Content.Load<Texture2D>("hackmon1P");
            // �n�b�N����1P��HPBar�摜�̃��[�h
            HPBarForHackmon1P = Content.Load<Texture2D>("HPBar");
            // �n�b�N����1P��HPGauge�摜�̃��[�h
            HPGaugeForHackmon1P = Content.Load<Texture2D>("HPGauge");
            // �n�b�N����1P�̃t�B�t�X���b�V���摜�̃��[�h
            hackmon1PfifSlash = Content.Load<Texture2D>("hackmonFifSlash");

            //�����蔻�����肷�锒�����̃��[�h
            ColliderChecker = Content.Load<Texture2D>("CollisionChecker");



            hackmon2P.Image = Content.Load<Texture2D>("hackmon2P");
            // �n�b�N����2P��HPBar�摜�̐錾
            HPBarForHackmon2P = Content.Load<Texture2D>("HPBar");
            // �n�b�N����2P��HPGauge�摜�̐錾
            HPGaugeForHackmon2P = Content.Load<Texture2D>("HPGauge"); ;



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for Colliders, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //�L�[�{�[�h�̏�Ԃ��擾
            KeyboardState = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //Esc�L�[���������Ƃ��ɏI��
            if (KeyboardState.IsKeyDown(Keys.Escape))
                this.Exit();


            // TODO: Add your update logic here

            //dasw�L�[�Ńn�b�N����1P���ړ�
            //d�������ꂽ��n�b�N����1P���E�ֈړ�
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                hackmon1P.position.X += 4;
                // �n�b�N����1P�̃t�B�t�X���b�V���摜���W�̐錾
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.X += 50;

                //�n�b�N�����PP�̃t�B�t�X���b�V���̈ʒu����Ƀn�b�N�����PP���O�ɕ\��
                hackmon1PfifSlashPosition.X += 4;

                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon1PFrame++;
                    //0�R�}�ڂ܂Ői�񂾂�0�R�}�ڂ܂Ŗ߂�
                    if (hackmon1PFrame > 0) hackmon1PFrame = 0;

                    //�񐔂��N���A
                    frame = 0;
                }




            }

            //a�������ꂽ��n�b�N����1P�����ֈړ�
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                hackmon1P.position.X -= 4;

                // �n�b�N����1P�̃t�B�t�X���b�V���摜���W���ړ������Ɍ�����
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.X -= 80;

                //�n�b�N�����PP�̃t�B�t�X���b�V���̈ʒu����Ƀn�b�N�����PP���O�ɕ\��
                hackmon1PfifSlashPosition.X -= 4;


                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon1PFrame++;
                    //1�R�}�ڂ܂Ői�񂾂�1�R�}�ڂ܂Ŗ߂�
                    if (hackmon1PFrame > 1) hackmon1PFrame = 1;

                    //�񐔂��N���A
                    frame = 0;
                }
            }

            //S�������ꂽ��n�b�N����1P�����Ɉړ�
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                hackmon1P.position.Y += 4;

                // �n�b�N����1P�̃t�B�t�X���b�V���摜���W���ړ������Ɍ�����
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.Y += 50;

                //�n�b�N�����PP�̃t�B�t�X���b�V���̈ʒu����Ƀn�b�N�����PP���O�ɕ\��
                hackmon1PfifSlashPosition.Y += 4;

                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon1PFrame++;
                    //2�R�}�ڂ܂Ői�񂾂�2�R�}�ڂ܂Ŗ߂�
                    if (hackmon1PFrame > 2) hackmon1PFrame = 2;

                    //�񐔂��N���A
                    frame = 0;
                }
            }

            //w�������ꂽ��n�b�N����1P����Ɉړ�
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                hackmon1P.position.Y -= 4;

                // �n�b�N����1P�̃t�B�t�X���b�V���摜���W���ړ������Ɍ�����
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.Y -= 80;

                //�n�b�N�����PP�̃t�B�t�X���b�V���̈ʒu����Ƀn�b�N�����PP���O�ɕ\��
                hackmon1PfifSlashPosition.Y -= 4;


                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon1PFrame++;
                    //3�R�}�ڂ܂Ői�񂾂�3�R�}�ڂ܂Ŗ߂�
                    if (hackmon1PFrame > 3) hackmon1PFrame = 3;

                    //�񐔂��N���A
                    frame = 0;
                }
            }


            //�����L�[�Ńn�b�N����2P���ړ�
            //���������ꂽ��X���W��4�s�N�Z�����Z����
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                hackmon2P.position.X -= 4;

                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon2PFrame++;
                    //0�R�}�ڂ܂Ői�񂾂�0�R�}�ڂ܂Ŗ߂�
                    if (hackmon2PFrame > 0) hackmon2PFrame = 0;

                    //�񐔂��N���A
                    frame = 0;
                }

            }

            //�E�������ꂽ��X���W��4�s�N�Z�����Z
            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                hackmon2P.position.X += 4;

                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon2PFrame++;
                    //1�R�}�ڂ܂Ői�񂾂�1�R�}�ڂ܂Ŗ߂�
                    if (hackmon2PFrame > 1) hackmon2PFrame = 1;

                    //�񐔂��N���A
                    frame = 0;
                }


            }


            //���������ꂽ��X���W��4�s�N�Z�����Z
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                hackmon2P.position.Y += 4;

                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon2PFrame++;
                    //2�R�}�ڂ܂Ői�񂾂�2�R�}�ڂ܂Ŗ߂�
                    if (hackmon2PFrame > 2) hackmon2PFrame = 2;

                    //�񐔂��N���A
                    frame = 0;
                }


            }


            //�オ�����ꂽ��X���W��4�s�N�Z�����Z����
            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                hackmon2P.position.Y -= 4;

                frame++;
                //0��Ăяo���ꂽ��R�}���ړ�������
                if (frame >= 0)
                {
                    //�R�}�ʒu�̈ړ�
                    hackmon2PFrame++;
                    //3�R�}�ڂ܂Ői�񂾂�3�R�}�ڂ܂Ŗ߂�
                    if (hackmon2PFrame > 3) hackmon2PFrame = 3;

                    //�񐔂��N���A
                    frame = 0;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //�w�i�摜dark-tech-background��`��
            spriteBatch.Draw(darkTechBackground, new Rectangle(0, 0, 800, 600), Color.White);

            //�n�b�N����1P�̉摜��`��
            spriteBatch.Draw(hackmon1P.Image, hackmon1P.position, new Rectangle(hackmon1PFrame * 65, 0, 65, 65), Color.White);
            // �n�b�N����1P��HPBar�摜��`��
            spriteBatch.Draw(HPBarForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // �n�b�N����1P��HPGauge�摜��`��
            spriteBatch.Draw(HPGaugeForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, HPwidthForhackmon1P, 20), Color.White);
            //Space�Ńn�b�N����1P�̃t�B�t�X���b�V���U��
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                // �n�b�N����1P�̃t�B�t�X���b�V���摜�`��
                //Rectangle��int����郁�\�b�h�Ȃ̂ŃL���X�g��float��int�ɕϊ�
                int castForHackmon1PfifSlashColliderX;
                castForHackmon1PfifSlashColliderX = (int)hackmon1PfifSlashPosition.X;
                int castForHackmon1PfifSlashColliderY;
                castForHackmon1PfifSlashColliderY = (int)hackmon1PfifSlashPosition.Y;

                Rectangle hackmon1PfifSlashCollider = new Rectangle(castForHackmon1PfifSlashColliderX, castForHackmon1PfifSlashColliderY, 90, 90);

                int castForHackmon2PimageColliderX;
                castForHackmon2PimageColliderX = (int)hackmon2P.position.X;
                int castForHackmon2PimageColliderY;
                castForHackmon2PimageColliderY = (int)hackmon2P.position.Y;

                Rectangle hackmon2PimageCollider = new Rectangle(castForHackmon2PimageColliderX, castForHackmon2PimageColliderY, 65, 65);

                spriteBatch.Draw(hackmon1PfifSlash, hackmon1PfifSlashPosition, new Rectangle(0, 0, 90, 90), Color.White);
                //�n�b�N����1P���t�B�t�X���b�V�������Ƃ��Ƀn�b�N����2P�ɓ���������n�b�N����2P�Ƀ_���[�W
                if (hackmon1PfifSlashCollider.Intersects(hackmon2PimageCollider))
                {
                    HPwidthForhackmon2P -= 1;
                }
            }
            //�t�B�t�X���b�V���̓����蔻�����肷�锼�����̐Ԃ���`��`��
            spriteBatch.Draw(ColliderChecker, hackmon1PfifSlashPosition, new Rectangle(0, 0, 90, 90), Color.Red * 0.5f);

            //�n�b�N����2P�̉摜��`��
            spriteBatch.Draw(hackmon2P.Image, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.White);
            //�n�b�N����2P�̓����蔻�����肷�锼�����̐Ԃ���`��`��
            spriteBatch.Draw(ColliderChecker, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.Green * 0.5f);
            // �n�b�N����2P��HPBar�摜�̐錾
            spriteBatch.Draw(HPBarForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // �n�b�N����2P��HPGauge�摜�̐錾
            spriteBatch.Draw(HPGaugeForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, HPwidthForhackmon2P, 20), Color.White);


            spriteBatch.End();


                    base.Draw(gameTime);
        }
    }
}
