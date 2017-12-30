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
        //モンスター画像の宣言
        public Texture2D Image;
        //モンスター画像の座標の宣言
        public Vector2 position;
    }

    public class Font
    {
        //フォントの宣言
        public SpriteFont font;
        //フォントの宣言
        public Vector2 position;
    }

    public struct Gauge
    {
        public int HP, x, y, w, h;
        public Texture2D HPBar, HPGauge;

        //HPの初期化メソッド
        public void Init(ContentManager Content, int x, int y, int w, int h)
        //変数ContentManager Contentは下記ブロックの変数healthBarを読み込むために使う
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

        //背景画像dark-tech-backgroundの宣言
        Texture2D darkTechBackground;

        //キーボードの状態を宣言
        KeyboardState KeyboardState;

        //ハックモン1Pのモンスタークラス
        Monster hackmon1P = new Monster();

        //フレームの宣言
        int frame = 0;
        // ハックモン1Pのコマ位置の宣言
        int hackmon1PFrame = 0;

        //ハックモン２Pのモンスタークラス
        Monster hackmon2P = new Monster();
        // ハックモン2Pのコマ位置の宣言
        int hackmon2PFrame = 0;

        //Gaugeストラクトの宣言
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
            //ハックモン1Pのスタート位置
            hackmon1P.position = new Vector2(20, 50);

            //ハックモン2Pのスタート位置
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
            //背景画像dark-tech-backgroundのロード
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
            //キーボードの状態を取得
            KeyboardState = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //Escキーを押したときに終了
            if (KeyboardState.IsKeyDown(Keys.Escape))
                this.Exit();


            // TODO: Add your update logic here

            float arrowKeyControlPositionValueX = 4;
            float arrowKeyControlPositionValueY = 4;

            //daswキーでハックモン1Pを移動
            //dが押されたらハックモン1Pが右へ移動
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                hackmon1P.position.X += arrowKeyControlPositionValueX;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon1PFrame++;
                    //0コマ目まで進んだら0コマ目まで戻す
                    if (hackmon1PFrame > 0) hackmon1PFrame = 0;

                    //回数をクリア
                    frame = 0;
                }
            }

            //aが押されたらハックモン1Pが左へ移動
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                hackmon1P.position.X -= arrowKeyControlPositionValueX;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon1PFrame++;
                    //1コマ目まで進んだら1コマ目まで戻す
                    if (hackmon1PFrame > 1) hackmon1PFrame = 1;

                    //回数をクリア
                    frame = 0;
                }
            }

            //Sが押されたらハックモン1Pが下に移動
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                hackmon1P.position.Y += arrowKeyControlPositionValueY;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon1PFrame++;
                    //2コマ目まで進んだら2コマ目まで戻す
                    if (hackmon1PFrame > 2) hackmon1PFrame = 2;

                    //回数をクリア
                    frame = 0;
                }
            }

            //wが押されたらハックモン1Pが上に移動
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                hackmon1P.position.Y -= arrowKeyControlPositionValueY;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon1PFrame++;
                    //3コマ目まで進んだら3コマ目まで戻す
                    if (hackmon1PFrame > 3) hackmon1PFrame = 3;

                    //回数をクリア
                    frame = 0;
                }
            }


            //方向キーでハックモン2Pを移動
            //左が押されたらX座標を4ピクセル減算する
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                hackmon2P.position.X -= arrowKeyControlPositionValueX;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon2PFrame++;
                    //0コマ目まで進んだら0コマ目まで戻す
                    if (hackmon2PFrame > 0) hackmon2PFrame = 0;

                    //回数をクリア
                    frame = 0;
                }

            }

            //右が押されたらX座標を4ピクセル加算
            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                hackmon2P.position.X += arrowKeyControlPositionValueX;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon2PFrame++;
                    //1コマ目まで進んだら1コマ目まで戻す
                    if (hackmon2PFrame > 1) hackmon2PFrame = 1;

                    //回数をクリア
                    frame = 0;
                }


            }


            //下が押されたらX座標を4ピクセル加算
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                hackmon2P.position.Y += arrowKeyControlPositionValueY;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon2PFrame++;
                    //2コマ目まで進んだら2コマ目まで戻す
                    if (hackmon2PFrame > 2) hackmon2PFrame = 2;

                    //回数をクリア
                    frame = 0;
                }


            }


            //上が押されたらX座標を4ピクセル減算する
            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                hackmon2P.position.Y -= arrowKeyControlPositionValueY;

                frame++;
                //0回呼び出されたらコマを移動させる
                if (frame >= 0)
                {
                    //コマ位置の移動
                    hackmon2PFrame++;
                    //3コマ目まで進んだら3コマ目まで戻す
                    if (hackmon2PFrame > 3) hackmon2PFrame = 3;

                    //回数をクリア
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
            //背景画像dark-tech-backgroundを描画
            spriteBatch.Draw(darkTechBackground, new Rectangle(0, 0, 800, 600), Color.White);

            //ハックモン1Pの画像を描画
            spriteBatch.Draw(hackmon1P.Image, hackmon1P.position, new Rectangle(hackmon1PFrame * 65, 0, 65, 65), Color.White);

            //ハックモン2Pの画像を描画
            spriteBatch.Draw(hackmon2P.Image, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.White);


            spriteBatch.End();


                    base.Draw(gameTime);
        }
    }
}
