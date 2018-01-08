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
    /// <summary>
    /// �n�b�N��������邽�߂̃N���X
    /// </summary>
    public class Hackmon
    {
        public Texture2D image;
        public Vector2 position;
        public Texture2D name;
        public Vector2 namePosition;
        public Texture2D jab;
        public Vector2 jabPosition;
        public Texture2D longRangeAttack;
        public Texture2D longRangeAttack2;
        public Vector2 longRangeAttackPosition;
        public Vector2 longRangeAttackPosition2;

        /// <summary>
        /// �n�b�N�����̃R���X�g���N�^�i�S�p�����[�^�̏������j
        /// </summary>
        /// <param name="Content">���\�[�X��ǂݍ��ނ��߂̕ϐ��i�g���Ƃ���Content�Ɠ��́j</param>
        /// <param name="image">�n�b�N�����̉摜</param>
        /// <param name="hackmonPositionX">�n�b�N������X���W</param>
        /// <param name="hackmonPositionY">�n�b�N������Y���W</param>
        /// <param name="name">�n�b�N�����̖��O�̉摜</param>
        /// <param name="namePositionX">�n�b�N�����̖��O��X���W</param>
        /// <param name="namePositionY">�n�b�N�����̖��O��Y���W</param>
        /// <param name="jab">�n�b�N�����̋ߐڍU���̉摜</param>
        /// <param name="jabPositionX">�n�b�N�����̋ߐڍU����X���W</param>
        /// <param name="jabPositionY">�n�b�N�����̋ߐڍU����Y���W</param>
        /// <param name="longRangeAttack">�n�b�N�����̉������U���̉摜</param>
        /// <param name="longRangeAttackPositionX">�n�b�N�����̉������U����X���W</param>
        /// <param name="longRangeAttackPositionY">�n�b�N�����̉������U����Y���W</param>
        public Hackmon(ContentManager Content, string image, int hackmonPositionX,int hackmonPositionY,string name,int namePositionX,int namePositionY,
            string jab,int jabPositionX, int jabPositionY, string longRangeAttack, int longRangeAttackPositionX, int longRangeAttackPositionY)
        {
            this.image = Content.Load<Texture2D>(image);
            this.position = new Vector2(hackmonPositionX, hackmonPositionY);
            this.name = Content.Load<Texture2D>(name);
            this.namePosition = new Vector2(namePositionX, namePositionY);
            this.jab = Content.Load<Texture2D>(jab);
            this.jabPosition = new Vector2(jabPositionX, jabPositionY);
            this.longRangeAttack = Content.Load<Texture2D>(longRangeAttack);
            this.longRangeAttackPosition = new Vector2(longRangeAttackPositionX, longRangeAttackPositionY);
        }


        public Hackmon()
        {
        }
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
        Hackmon hackmon1P = new Hackmon();

        //�t���[���̐錾
        int frame = 0;
        // �n�b�N����1P�̃R�}�ʒu�̐錾
        int hackmon1PFrame = 0;
        // �n�b�N����1P��HPBar�摜�̐錾
        Texture2D HPBarForHackmon1P;
        // �n�b�N����1P��HPGauge�摜�̐錾
        Texture2D HPGaugeForHackmon1P;
        //�n�b�N�����PP��HP�̐錾
        float HPwidthForhackmon1P;
        //�n�b�N����1P�̖��O��錾


        //�����蔻�����肷�锒�����̐錾
        Texture2D ColliderChecker;

        //�n�b�N�����QP�̃����X�^�[�N���X
        Hackmon hackmon2P = new Hackmon();
        // �n�b�N����2P�̃R�}�ʒu�̐錾
        int hackmon2PFrame = 0;
        // �n�b�N����2P��HPBar�摜�̐錾
        Texture2D HPBarForHackmon2P;
        // �n�b�N����2P��HPGauge�摜�̐錾
        Texture2D HPGaugeForHackmon2P;
        //�n�b�N����2P��HP�̐錾
        float HPwidthForhackmon2P;

        //�n�b�N�����PP���n�b�N����2P�̂ǂ��炩��HP��0�ɂȂ�����uComplete�v�ƕ\������(�錾)
        Texture2D Complete;
        //�L�����̕����X�s�[�h��錾
        int walkSpeed;


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
            hackmon1P.position = new Vector2(200, 200);
            //�n�b�N�����PP��HP�̏�����
            HPwidthForhackmon1P = 250.0f;
            // �n�b�N����1P�̋ߐڍU���摜���W�̐錾
            this.hackmon1P.jabPosition = new Vector2(250, 200);
            // �n�b�N����1P�̉������U���摜���W�̐錾
            this.hackmon1P.longRangeAttackPosition = new Vector2(250, 200);


            //�n�b�N����1P�̖��O�̈ʒu�̏�����
            hackmon1P.namePosition = new Vector2(200, 170);




            //�n�b�N����2P�̃X�^�[�g�ʒu�̏�����
            hackmon2P.position = new Vector2(500, 200);
            //�n�b�N����2P��HP�̏�����
            HPwidthForhackmon2P = 250.0f;
            // �n�b�N����2P�̋ߐڍU���摜���W�̐錾
            this.hackmon2P.jabPosition = new Vector2(450, 200);
            // �n�b�N����2P�̉������U���摜2���W�̐錾
            this.hackmon2P.longRangeAttackPosition2 = new Vector2(450, 200);


            //�L�����̕����X�s�[�h��������
            walkSpeed = 10;


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
            hackmon1P.image = Content.Load<Texture2D>("hackmon1P");
            // �n�b�N����1P��HPBar�摜�̃��[�h
            HPBarForHackmon1P = Content.Load<Texture2D>("HPBar");
            // �n�b�N����1P��HPGauge�摜�̃��[�h
            HPGaugeForHackmon1P = Content.Load<Texture2D>("HPGauge");
            // �n�b�N����1P�̋ߐڍU���摜�̃��[�h
            hackmon1P.jab = Content.Load<Texture2D>("hackmonjab");
            // �n�b�N����1P�̉������U���摜�̃��[�h
            hackmon1P.longRangeAttack = Content.Load<Texture2D>("hackmonlongRangeAttack");
            //�n�b�N����1P�̖��O�����[�h
            hackmon1P.name = Content.Load<Texture2D>("hackmon1Pname");




            //�R���X�g���N�^�̎g�p���K�Ŏg����

            //hackmon1P = new Hackmon(Content, "hackmon1P", 250, 200, "hackmon1Pname", 250, 180, "hackmonJab", 300, 200,
            //    "hackmonLongRangeAttack", 300, 200);



            //�����蔻�����肷�锒�����̃��[�h
            ColliderChecker = Content.Load<Texture2D>("CollisionChecker");



            hackmon2P.image = Content.Load<Texture2D>("hackmon2P");
            // �n�b�N����2P��HPBar�摜�̐錾
            HPBarForHackmon2P = Content.Load<Texture2D>("HPBar");
            // �n�b�N����2P��HPGauge�摜�̐錾
            HPGaugeForHackmon2P = Content.Load<Texture2D>("HPGauge"); ;
            // �n�b�N����2P�̋ߐڍU���摜�̃��[�h
            hackmon2P.jab = Content.Load<Texture2D>("hackmonjab");
            // �n�b�N����1P�̉������U���摜�̃��[�h
            hackmon2P.longRangeAttack2 = Content.Load<Texture2D>("hackmonlongRangeAttack2");


            //�n�b�N�����PP���n�b�N����2P�̂ǂ��炩��HP��0�ɂȂ�����uComplete�v�ƕ\������(���[�h)
            Complete = Content.Load<Texture2D>("Complete");

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
                hackmon1P.position.X += walkSpeed;
                //d�������ꂽ��n�b�N����1P�̖��O�����Ɉړ�
                hackmon1P.namePosition.X += walkSpeed;

                // �n�b�N����1P�̋ߐڍU���摜���W�̐錾
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.X += 50;

                // �n�b�N����1P�̉������U���摜���W�̐錾
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.X += 50;



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
                hackmon1P.position.X -= walkSpeed;
                //a�������ꂽ��n�b�N����1P�̖��O�����Ɉړ�
                hackmon1P.namePosition.X -= walkSpeed;


                // �n�b�N����1P�̋ߐڍU���摜���W���ړ������Ɍ�����
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.X -= 80;

                // �n�b�N����1P�̉������U���摜���W�̐錾
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.X -= 50;


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
                hackmon1P.position.Y += walkSpeed;
                //s�������ꂽ��n�b�N����1P�̖��O�����Ɉړ�
                hackmon1P.namePosition.Y += walkSpeed;


                // �n�b�N����1P�̋ߐڍU���摜���W���ړ������Ɍ�����
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.Y += 50;

                // �n�b�N����1P�̉������U���摜���W�̐錾
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.Y += 50;


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
                hackmon1P.position.Y -= walkSpeed;
                //w�������ꂽ��n�b�N����1P�̖��O����Ɉړ�
                hackmon1P.namePosition.Y -= walkSpeed;

                // �n�b�N����1P�̋ߐڍU���摜���W���ړ������Ɍ�����
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.Y -= 80;

                // �n�b�N����1P�̉������U���摜���W�̐錾
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.Y -= 50;



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

            //�n�b�N����1P����ʊO�֏o�Ȃ��悤�ɂ���
            if (hackmon1P.position.X <= 0) hackmon1P.position.X = 0;
            if (hackmon1P.position.X >= 800 - 65) hackmon1P.position.X = 800 - 65;
            if (hackmon1P.position.Y <= 0) hackmon1P.position.Y = 0;
            if (hackmon1P.position.Y >= 600 - 180) hackmon1P.position.Y = 600 - 180;



            //�����L�[�Ńn�b�N����2P���ړ�
            //���������ꂽ��X���W��4�s�N�Z�����Z����
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                hackmon2P.position.X -= walkSpeed;
                // �n�b�N����2P�̋ߐڍU���摜���W�̐錾
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.X -= 80;



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
                hackmon2P.position.X += walkSpeed;
                // �n�b�N����2P�̋ߐڍU���摜���W���ړ������Ɍ�����
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.X += 50;


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
                hackmon2P.position.Y += walkSpeed;
                // �n�b�N����2P�̋ߐڍU���摜���W���ړ������Ɍ�����
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.Y += 50;


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
                hackmon2P.position.Y -= walkSpeed;
                // �n�b�N����2P�̋ߐڍU���摜���W���ړ������Ɍ�����
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.Y -= 80;


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
            Rectangle darkTechBackgroundCollider = new Rectangle(0, 0, 800, 600);
            spriteBatch.Draw(darkTechBackground, new Rectangle(0, 0, 800, 600), Color.White);
            //�w�i�摜dark-tech-background�̓����蔻�����肷�锼�����̗ΐF�̋�`��`��
            spriteBatch.Draw(ColliderChecker, new Vector2(0,0), new Rectangle(0, 0, 800, 600), Color.Blue * 0.5f);


            //�n�b�N����1P�̉摜��`��
            spriteBatch.Draw(hackmon1P.image, hackmon1P.position, new Rectangle(hackmon1PFrame * 65, 0, 65, 65), Color.White);
            //�n�b�N����1P�̓����蔻�����肷�锼�����̗ΐF�̋�`��`��
            spriteBatch.Draw(ColliderChecker, hackmon1P.position, new Rectangle(hackmon1PFrame * 65, 0, 65, 65), Color.Green * 0.5f);
            // �n�b�N����1P��HPBar�摜��`��
            spriteBatch.Draw(HPBarForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // �n�b�N����1P��HPGauge�摜��`��
            int castForHPwidthForhackmon1P;
            castForHPwidthForhackmon1P = (int)HPwidthForhackmon1P;
            spriteBatch.Draw(HPGaugeForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, castForHPwidthForhackmon1P, 20), Color.White);
            //Space�Ńn�b�N����1P�̋ߐڍU���U��
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                // �n�b�N����1P�̋ߐڍU���摜�`��
                //Rectangle��int����郁�\�b�h�Ȃ̂ŃL���X�g��float��int�ɕϊ�
                int castForHackmon1PjabColliderX;
                castForHackmon1PjabColliderX = (int)hackmon1P.jabPosition.X;
                int castForHackmon1PjabColliderY;
                castForHackmon1PjabColliderY = (int)hackmon1P.jabPosition.Y;

                Rectangle hackmon1PjabCollider = new Rectangle(castForHackmon1PjabColliderX, castForHackmon1PjabColliderY, 90, 90);

                int castForHackmon2PimageColliderX;
                castForHackmon2PimageColliderX = (int)hackmon2P.position.X;
                int castForHackmon2PimageColliderY;
                castForHackmon2PimageColliderY = (int)hackmon2P.position.Y;

                Rectangle hackmon2PimageCollider = new Rectangle(castForHackmon2PimageColliderX, castForHackmon2PimageColliderY, 65, 65);

                spriteBatch.Draw(hackmon1P.jab, hackmon1P.jabPosition, new Rectangle(0, 0, 90, 90), Color.White);
                //�n�b�N����1P���ߐڍU�������Ƃ��Ƀn�b�N����2P�ɓ���������n�b�N����2P�Ƀ_���[�W
                if (hackmon1PjabCollider.Intersects(hackmon2PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon2P -= 10.0f ;
                }
            }
            //�n�b�N�����PP�̋ߐڍU���̓����蔻�����肷�锼�����̐Ԃ���`��`��
            spriteBatch.Draw(ColliderChecker, hackmon1P.jabPosition, new Rectangle(0, 0, 90, 90), Color.Yellow * 0.5f);
           
            
            //f�Ńn�b�N����1P�̉������U���U��
            if (KeyboardState.IsKeyDown(Keys.F))
            {
                // �n�b�N����1P�̉������U���摜�`��
                //Rectangle��int����郁�\�b�h�Ȃ̂ŃL���X�g��float��int�ɕϊ�
                int castForHackmon1PlongRangeAttackColliderX;
                castForHackmon1PlongRangeAttackColliderX = (int)hackmon1P.longRangeAttackPosition.X;
                int castForHackmon1PlongRangeAttackColliderY;
                castForHackmon1PlongRangeAttackColliderY = (int)hackmon1P.longRangeAttackPosition.Y;

                Rectangle hackmon1PlongRangeAttackCollider = new Rectangle(castForHackmon1PlongRangeAttackColliderX, castForHackmon1PlongRangeAttackColliderY, 90, 90);

                int castForHackmon2PimageColliderX;
                castForHackmon2PimageColliderX = (int)hackmon2P.position.X;
                int castForHackmon2PimageColliderY;
                castForHackmon2PimageColliderY = (int)hackmon2P.position.Y;

                Rectangle hackmon2PimageCollider = new Rectangle(castForHackmon2PimageColliderX, castForHackmon2PimageColliderY, 65, 65);



                if (hackmon1PlongRangeAttackCollider.Intersects(darkTechBackgroundCollider))
                {

                    spriteBatch.Draw(hackmon1P.longRangeAttack, hackmon1P.longRangeAttackPosition, new Rectangle(0, 0, 90, 90), Color.White);

                        

                    //�ǂ�������牓�����U���������ꂽ�ʒu���璼���Ɉ��X�s�[�h�ł܂�������ԁH

                    //1��f�������ꂽ��hackmon1PlongRangeAttackPosition�Ƀn�b�N�����̐i�s������
                    //��������x���Ay���ɂ��ꂼ��v�Z������ĉ�ʊO�܂ŉ������U�������


                }

                //�ǂ��������n�b�N����1P�̉������U�����\����ʊO�܂ŕ\�����ꑱ����H

                //f�{�^������������E������f�������ŉ������U�����łĂ�悤�ɂȂ����if�{�^���𗣂����牓�����U����������j
                //f�����Ĉ��ړ����Ȃ��ƍēx�������U�����łĂȂ�
                //f�ŉ������U����1��ł��āA�ړ����Ȃ��ōēx�������U�������ƑO�ł����Ƃ��납�牓�����U��
                //���������ĉE�����֔��ł���
                //����f�������āA��񉓋����U������������A��ʊO�ɏo��܂ŉ������U�����p������
                //�n�b�N����1P�̐i�s�����Ɍ������Ĉړ����Ă����悤�ɂ���
                if (hackmon1PlongRangeAttackCollider.Intersects(darkTechBackgroundCollider))
                {
                    hackmon1P.longRangeAttackPosition.X += 20;
                }




                //�n�b�N����1P���������U�������Ƃ��Ƀn�b�N����2P�ɓ���������n�b�N����2P�Ƀ_���[�W
                if (hackmon1PlongRangeAttackCollider.Intersects(hackmon2PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon2P -= 10.0f;
                }
            }
            //�n�b�N�����PP�̉������U���̓����蔻�����肷�锼�����̐Ԃ���`��`��
            spriteBatch.Draw(ColliderChecker, hackmon1P.longRangeAttackPosition, new Rectangle(0, 0, 90, 90), Color.Red * 0.5f);


            //�n�b�N����1P�̖��O��`��
            spriteBatch.Draw(hackmon1P.name, hackmon1P.namePosition, new Rectangle(0, 0, 170, 30), Color.White);


            //�n�b�N����2P�̉摜��`��
            spriteBatch.Draw(hackmon2P.image, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.White);
            //�n�b�N����2P�̓����蔻�����肷�锼�����̗ΐF�̋�`��`��
            spriteBatch.Draw(ColliderChecker, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.Green * 0.5f);
            // �n�b�N����2P��HPBar�摜�̐錾
            spriteBatch.Draw(HPBarForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // �n�b�N����2P��HPGauge�摜�̐錾
            int castForHPwidthForhackmon2P;
            castForHPwidthForhackmon2P = (int)HPwidthForhackmon2P;
            spriteBatch.Draw(HPGaugeForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, castForHPwidthForhackmon2P, 20), Color.White);
            //Enter�Ńn�b�N����2P�̋ߐڍU���U��
            if (KeyboardState.IsKeyDown(Keys.Enter))
            {
                // �n�b�N����2P�̋ߐڍU���摜�`��
                //Rectangle��int����郁�\�b�h�Ȃ̂ŃL���X�g��float��int�ɕϊ�
                int castForHackmon2PjabColliderX;
                castForHackmon2PjabColliderX = (int)hackmon2P.jabPosition.X;
                int castForHackmon2PjabColliderY;
                castForHackmon2PjabColliderY = (int)hackmon2P.jabPosition.Y;

                Rectangle hackmon2PjabCollider = new Rectangle(castForHackmon2PjabColliderX, castForHackmon2PjabColliderY, 90, 90);

                int castForHackmon1PimageColliderX;
                castForHackmon1PimageColliderX = (int)hackmon1P.position.X;
                int castForHackmon1PimageColliderY;
                castForHackmon1PimageColliderY = (int)hackmon1P.position.Y;

                Rectangle hackmon1PimageCollider = new Rectangle(castForHackmon1PimageColliderX, castForHackmon1PimageColliderY, 65, 65);

                spriteBatch.Draw(hackmon2P.jab, hackmon2P.jabPosition, new Rectangle(0, 0, 90, 90), Color.White);
                //�n�b�N����2P���ߐڍU�������Ƃ��Ƀn�b�N����1P�ɓ���������n�b�N����2P�Ƀ_���[�W
                if (hackmon2PjabCollider.Intersects(hackmon1PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon1P -= 10.0f;
                }
            }
            //�n�b�N����2P�̋ߐڍU���̓����蔻�����肷�锼�����̐Ԃ���`��`��
            spriteBatch.Draw(ColliderChecker, hackmon2P.jabPosition, new Rectangle(0, 0, 90, 90), Color.Red * 0.5f);



            //f�Ńn�b�N����2P�̉������U���U��
            if (KeyboardState.IsKeyDown(Keys.L))
            {
                // �n�b�N����1P�̉������U���摜�`��
                //Rectangle��int����郁�\�b�h�Ȃ̂ŃL���X�g��float��int�ɕϊ�
                int castForHackmon2PlongRangeAttackColliderX;
                castForHackmon2PlongRangeAttackColliderX = (int)hackmon2P.longRangeAttackPosition2.X;
                int castForHackmon2PlongRangeAttackColliderY;
                castForHackmon2PlongRangeAttackColliderY = (int)hackmon2P.longRangeAttackPosition2.Y;

                Rectangle hackmon2PlongRangeAttackCollider = new Rectangle(castForHackmon2PlongRangeAttackColliderX, castForHackmon2PlongRangeAttackColliderY, 190, 190);

                int castForHackmon1PimageColliderX;
                castForHackmon1PimageColliderX = (int)hackmon1P.position.X;
                int castForHackmon1PimageColliderY;
                castForHackmon1PimageColliderY = (int)hackmon1P.position.Y;

                Rectangle hackmon1PimageCollider = new Rectangle(castForHackmon1PimageColliderX, castForHackmon1PimageColliderY, 65, 65);



                if (hackmon2PlongRangeAttackCollider.Intersects(darkTechBackgroundCollider))
                {

                    spriteBatch.Draw(hackmon2P.longRangeAttack2, hackmon2P.longRangeAttackPosition2, new Rectangle(0, 0, 190, 190), Color.White);



                    //�ǂ�������牓�����U���������ꂽ�ʒu���璼���Ɉ��X�s�[�h�ł܂�������ԁH

                    //1��f�������ꂽ��hackmon2PlongRangeAttackPosition�Ƀn�b�N�����̐i�s������
                    //��������x���Ay���ɂ��ꂼ��v�Z������ĉ�ʊO�܂ŉ������U�������


                }

                //�ǂ��������n�b�N����1P�̉������U�����\����ʊO�܂ŕ\�����ꑱ����H

                //f�{�^������������E������f�������ŉ������U�����łĂ�悤�ɂȂ����if�{�^���𗣂����牓�����U����������j
                //f�����Ĉ��ړ����Ȃ��ƍēx�������U�����łĂȂ�
                //f�ŉ������U����1��ł��āA�ړ����Ȃ��ōēx�������U�������ƑO�ł����Ƃ��납�牓�����U��
                //���������ĉE�����֔��ł���
                //����f�������āA��񉓋����U������������A��ʊO�ɏo��܂ŉ������U�����p������
                //�n�b�N����2P�̐i�s�����Ɍ������Ĉړ����Ă����悤�ɂ���
                if (hackmon2PlongRangeAttackCollider.Intersects(darkTechBackgroundCollider))
                {
                    hackmon2P.longRangeAttackPosition2.X -= 10;
                }




                //�n�b�N����2P���������U�������Ƃ��Ƀn�b�N����1P�ɓ���������n�b�N����1P�Ƀ_���[�W
                if (hackmon2PlongRangeAttackCollider.Intersects(hackmon1PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon1P -= 8.0f;
                }
            }
            //�n�b�N����2P�̉������U���̓����蔻�����肷�锼�����̐Ԃ���`��`��
            spriteBatch.Draw(ColliderChecker, hackmon2P.longRangeAttackPosition, new Rectangle(0, 0, 190, 190), Color.Red * 0.5f);




            //���̋@�\

            //�n�b�N�����PP���n�b�N����2P�̂ǂ��炩��HP��0�ɂȂ�����Q�[�����I�����
            //Exit���邩�Q�[�����ĊJ�ł���
            //�ǂ�����čĊJ����H
            //���̗̓Q�[�W�ƃn�b�N�����̈ʒu���X�^�[�g���ɖ߂�

            if (HPwidthForhackmon1P <= 0 || HPwidthForhackmon2P <= 0)
            {
                spriteBatch.Draw(Complete, new Vector2(300, 300), new Rectangle(0, 0, 500, 100), Color.White);
                walkSpeed = 1;�@//HP��0�ɂȂ�����Ɉړ�����ƃt���[�����[�g�������ăQ�[����
                //������x�n�߂鎞�Ԃ��x���Ȃ�

                frame++;
                //�Q�[����������x���܂ł̗]�C�̎���
                if (frame >= 60)
                {
                    //�Q�[����������x���
                    Initialize();

                    spriteBatch.Begin();

                    //�񐔂��N���A
                    frame = 0;
                }

                




                //Console.WriteLine("���E�q�g�V���E�u����H:y/n");
                //var playerAnswer = Console.ReadLine();
                //if (playerAnswer == "y")
                //{
                //    Initialize();
                //}
                //if (playerAnswer == "n")
                //{
                //    this.Exit();
                //}
            }



            spriteBatch.End();


                    base.Draw(gameTime);
        }
    }
}
