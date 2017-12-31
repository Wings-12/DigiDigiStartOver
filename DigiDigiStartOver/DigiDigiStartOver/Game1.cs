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
        // ハックモン1PのHPBar画像の宣言
        Texture2D HPBarForHackmon1P;
        // ハックモン1PのHPGauge画像の宣言
        Texture2D HPGaugeForHackmon1P;
        // ハックモン1Pのフィフスラッシュ画像の宣言
        Texture2D hackmon1PfifSlash;
        // ハックモン1Pのフィフスラッシュ画像座標の宣言
        Vector2 hackmon1PfifSlashPosition;
        //ハックモン１PのHPの宣言
        int HPwidthForhackmon1P;

        //当たり判定を特定する白い紙の宣言
        Texture2D ColliderChecker;


        //ハックモン２Pのモンスタークラス
        Monster hackmon2P = new Monster();
        // ハックモン2Pのコマ位置の宣言
        int hackmon2PFrame = 0;
        // ハックモン2PのHPBar画像の宣言
        Texture2D HPBarForHackmon2P;
        // ハックモン2PのHPGauge画像の宣言
        Texture2D HPGaugeForHackmon2P;
        //ハックモン2PのHPの宣言
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
            //ハックモン1Pのスタート位置の初期化
            hackmon1P.position = new Vector2(20, 50);
            //ハックモン１PのHPの初期化
            HPwidthForhackmon1P = 250;


            //ハックモン2Pのスタート位置の初期化
            hackmon2P.position = new Vector2(720, 50);
            //ハックモン2PのHPの初期化
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
            //背景画像dark-tech-backgroundのロード
            darkTechBackground = Content.Load<Texture2D>("dark-tech-background");
            //ハックモン1P画像のロード
            hackmon1P.Image = Content.Load<Texture2D>("hackmon1P");
            // ハックモン1PのHPBar画像のロード
            HPBarForHackmon1P = Content.Load<Texture2D>("HPBar");
            // ハックモン1PのHPGauge画像のロード
            HPGaugeForHackmon1P = Content.Load<Texture2D>("HPGauge");
            // ハックモン1Pのフィフスラッシュ画像のロード
            hackmon1PfifSlash = Content.Load<Texture2D>("hackmonFifSlash");

            //当たり判定を特定する白い紙のロード
            ColliderChecker = Content.Load<Texture2D>("CollisionChecker");



            hackmon2P.Image = Content.Load<Texture2D>("hackmon2P");
            // ハックモン2PのHPBar画像の宣言
            HPBarForHackmon2P = Content.Load<Texture2D>("HPBar");
            // ハックモン2PのHPGauge画像の宣言
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
            //キーボードの状態を取得
            KeyboardState = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //Escキーを押したときに終了
            if (KeyboardState.IsKeyDown(Keys.Escape))
                this.Exit();


            // TODO: Add your update logic here

            //daswキーでハックモン1Pを移動
            //dが押されたらハックモン1Pが右へ移動
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                hackmon1P.position.X += 4;
                // ハックモン1Pのフィフスラッシュ画像座標の宣言
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.X += 50;

                //ハックモン１Pのフィフスラッシュの位置を常にハックモン１Pより前に表示
                hackmon1PfifSlashPosition.X += 4;

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
                hackmon1P.position.X -= 4;

                // ハックモン1Pのフィフスラッシュ画像座標を移動方向に向ける
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.X -= 80;

                //ハックモン１Pのフィフスラッシュの位置を常にハックモン１Pより前に表示
                hackmon1PfifSlashPosition.X -= 4;


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
                hackmon1P.position.Y += 4;

                // ハックモン1Pのフィフスラッシュ画像座標を移動方向に向ける
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.Y += 50;

                //ハックモン１Pのフィフスラッシュの位置を常にハックモン１Pより前に表示
                hackmon1PfifSlashPosition.Y += 4;

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
                hackmon1P.position.Y -= 4;

                // ハックモン1Pのフィフスラッシュ画像座標を移動方向に向ける
                hackmon1PfifSlashPosition = hackmon1P.position;
                hackmon1PfifSlashPosition.Y -= 80;

                //ハックモン１Pのフィフスラッシュの位置を常にハックモン１Pより前に表示
                hackmon1PfifSlashPosition.Y -= 4;


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
                hackmon2P.position.X -= 4;

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
                hackmon2P.position.X += 4;

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
                hackmon2P.position.Y += 4;

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
                hackmon2P.position.Y -= 4;

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
            // ハックモン1PのHPBar画像を描画
            spriteBatch.Draw(HPBarForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // ハックモン1PのHPGauge画像を描画
            spriteBatch.Draw(HPGaugeForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, HPwidthForhackmon1P, 20), Color.White);
            //Spaceでハックモン1Pのフィフスラッシュ攻撃
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                // ハックモン1Pのフィフスラッシュ画像描画
                //Rectangleはintを取るメソッドなのでキャストでfloatをintに変換
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
                //ハックモン1Pがフィフスラッシュしたときにハックモン2Pに当たったらハックモン2Pにダメージ
                if (hackmon1PfifSlashCollider.Intersects(hackmon2PimageCollider))
                {
                    HPwidthForhackmon2P -= 1;
                }
            }
            //フィフスラッシュの当たり判定を特定する半透明の赤い矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon1PfifSlashPosition, new Rectangle(0, 0, 90, 90), Color.Red * 0.5f);

            //ハックモン2Pの画像を描画
            spriteBatch.Draw(hackmon2P.Image, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.White);
            //ハックモン2Pの当たり判定を特定する半透明の赤い矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.Green * 0.5f);
            // ハックモン2PのHPBar画像の宣言
            spriteBatch.Draw(HPBarForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // ハックモン2PのHPGauge画像の宣言
            spriteBatch.Draw(HPGaugeForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, HPwidthForhackmon2P, 20), Color.White);


            spriteBatch.End();


                    base.Draw(gameTime);
        }
    }
}
