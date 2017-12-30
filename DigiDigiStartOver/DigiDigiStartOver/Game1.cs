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

    public struct Gauge
    {
        public int HP, x, y, w, h;
        public Texture2D HPBar, HPGauge;

        //HP�̏��������\�b�h
        public void Init(ContentManager Content, int x, int y, int w, int h)
        //�ϐ�ContentManager Content�͉��L�u���b�N�̕ϐ�healthBar��ǂݍ��ނ��߂Ɏg��
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            HPBar = Content.Load<Texture2D>("HPBar");
            HPBar = Content.Load<Texture2D>("HPGauge");
        }
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

        //�n�b�N�����QP�̃����X�^�[�N���X
        Monster hackmon2P = new Monster();
        // �n�b�N����2P�̃R�}�ʒu�̐錾
        int hackmon2PFrame = 0;

        //Gauge�X�g���N�g�̐錾
        Gauge gauge1;



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
            //�n�b�N����1P�̃X�^�[�g�ʒu
            hackmon1P.position = new Vector2(20, 50);

            //�n�b�N����2P�̃X�^�[�g�ʒu
            hackmon2P.position = new Vector2(720, 50);

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
            hackmon1P.Image = Content.Load<Texture2D>("hackmon1P");
            hackmon2P.Image = Content.Load<Texture2D>("hackmon2P");


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
        /// checking for collisions, gathering input, and playing audio.
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

            float arrowKeyControlPositionValueX = 4;
            float arrowKeyControlPositionValueY = 4;

            //dasw�L�[�Ńn�b�N����1P���ړ�
            //d�������ꂽ��n�b�N����1P���E�ֈړ�
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                hackmon1P.position.X += arrowKeyControlPositionValueX;

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
                hackmon1P.position.X -= arrowKeyControlPositionValueX;

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
                hackmon1P.position.Y += arrowKeyControlPositionValueY;

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
                hackmon1P.position.Y -= arrowKeyControlPositionValueY;

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
                hackmon2P.position.X -= arrowKeyControlPositionValueX;

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
                hackmon2P.position.X += arrowKeyControlPositionValueX;

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
                hackmon2P.position.Y += arrowKeyControlPositionValueY;

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
                hackmon2P.position.Y -= arrowKeyControlPositionValueY;

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

            //�n�b�N����2P�̉摜��`��
            spriteBatch.Draw(hackmon2P.Image, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.White);


            spriteBatch.End();


                    base.Draw(gameTime);
        }
    }
}
