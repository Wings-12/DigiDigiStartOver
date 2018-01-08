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
    /// ハックモンを作るためのクラス
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
        /// ハックモンのコンストラクタ（全パラメータの初期化）
        /// </summary>
        /// <param name="Content">リソースを読み込むための変数（使うときはContentと入力）</param>
        /// <param name="image">ハックモンの画像</param>
        /// <param name="hackmonPositionX">ハックモンのX座標</param>
        /// <param name="hackmonPositionY">ハックモンのY座標</param>
        /// <param name="name">ハックモンの名前の画像</param>
        /// <param name="namePositionX">ハックモンの名前のX座標</param>
        /// <param name="namePositionY">ハックモンの名前のY座標</param>
        /// <param name="jab">ハックモンの近接攻撃の画像</param>
        /// <param name="jabPositionX">ハックモンの近接攻撃のX座標</param>
        /// <param name="jabPositionY">ハックモンの近接攻撃のY座標</param>
        /// <param name="longRangeAttack">ハックモンの遠距離攻撃の画像</param>
        /// <param name="longRangeAttackPositionX">ハックモンの遠距離攻撃のX座標</param>
        /// <param name="longRangeAttackPositionY">ハックモンの遠距離攻撃のY座標</param>
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
        Hackmon hackmon1P = new Hackmon();

        //フレームの宣言
        int frame = 0;
        // ハックモン1Pのコマ位置の宣言
        int hackmon1PFrame = 0;
        // ハックモン1PのHPBar画像の宣言
        Texture2D HPBarForHackmon1P;
        // ハックモン1PのHPGauge画像の宣言
        Texture2D HPGaugeForHackmon1P;
        //ハックモン１PのHPの宣言
        float HPwidthForhackmon1P;
        //ハックモン1Pの名前を宣言


        //当たり判定を特定する白い紙の宣言
        Texture2D ColliderChecker;

        //ハックモン２Pのモンスタークラス
        Hackmon hackmon2P = new Hackmon();
        // ハックモン2Pのコマ位置の宣言
        int hackmon2PFrame = 0;
        // ハックモン2PのHPBar画像の宣言
        Texture2D HPBarForHackmon2P;
        // ハックモン2PのHPGauge画像の宣言
        Texture2D HPGaugeForHackmon2P;
        //ハックモン2PのHPの宣言
        float HPwidthForhackmon2P;

        //ハックモン１Pかハックモン2PのどちらかのHPが0になったら「Complete」と表示する(宣言)
        Texture2D Complete;
        //キャラの歩くスピードを宣言
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
            //ハックモン1Pのスタート位置の初期化
            hackmon1P.position = new Vector2(200, 200);
            //ハックモン１PのHPの初期化
            HPwidthForhackmon1P = 250.0f;
            // ハックモン1Pの近接攻撃画像座標の宣言
            this.hackmon1P.jabPosition = new Vector2(250, 200);
            // ハックモン1Pの遠距離攻撃画像座標の宣言
            this.hackmon1P.longRangeAttackPosition = new Vector2(250, 200);


            //ハックモン1Pの名前の位置の初期化
            hackmon1P.namePosition = new Vector2(200, 170);




            //ハックモン2Pのスタート位置の初期化
            hackmon2P.position = new Vector2(500, 200);
            //ハックモン2PのHPの初期化
            HPwidthForhackmon2P = 250.0f;
            // ハックモン2Pの近接攻撃画像座標の宣言
            this.hackmon2P.jabPosition = new Vector2(450, 200);
            // ハックモン2Pの遠距離攻撃画像2座標の宣言
            this.hackmon2P.longRangeAttackPosition2 = new Vector2(450, 200);


            //キャラの歩くスピードを初期化
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
            //背景画像dark-tech-backgroundのロード
            darkTechBackground = Content.Load<Texture2D>("dark-tech-background");
            //ハックモン1P画像のロード
            hackmon1P.image = Content.Load<Texture2D>("hackmon1P");
            // ハックモン1PのHPBar画像のロード
            HPBarForHackmon1P = Content.Load<Texture2D>("HPBar");
            // ハックモン1PのHPGauge画像のロード
            HPGaugeForHackmon1P = Content.Load<Texture2D>("HPGauge");
            // ハックモン1Pの近接攻撃画像のロード
            hackmon1P.jab = Content.Load<Texture2D>("hackmonjab");
            // ハックモン1Pの遠距離攻撃画像のロード
            hackmon1P.longRangeAttack = Content.Load<Texture2D>("hackmonlongRangeAttack");
            //ハックモン1Pの名前をロード
            hackmon1P.name = Content.Load<Texture2D>("hackmon1Pname");




            //コンストラクタの使用練習で使った

            //hackmon1P = new Hackmon(Content, "hackmon1P", 250, 200, "hackmon1Pname", 250, 180, "hackmonJab", 300, 200,
            //    "hackmonLongRangeAttack", 300, 200);



            //当たり判定を特定する白い紙のロード
            ColliderChecker = Content.Load<Texture2D>("CollisionChecker");



            hackmon2P.image = Content.Load<Texture2D>("hackmon2P");
            // ハックモン2PのHPBar画像の宣言
            HPBarForHackmon2P = Content.Load<Texture2D>("HPBar");
            // ハックモン2PのHPGauge画像の宣言
            HPGaugeForHackmon2P = Content.Load<Texture2D>("HPGauge"); ;
            // ハックモン2Pの近接攻撃画像のロード
            hackmon2P.jab = Content.Load<Texture2D>("hackmonjab");
            // ハックモン1Pの遠距離攻撃画像のロード
            hackmon2P.longRangeAttack2 = Content.Load<Texture2D>("hackmonlongRangeAttack2");


            //ハックモン１Pかハックモン2PのどちらかのHPが0になったら「Complete」と表示する(ロード)
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
                hackmon1P.position.X += walkSpeed;
                //dが押されたらハックモン1Pの名前が左に移動
                hackmon1P.namePosition.X += walkSpeed;

                // ハックモン1Pの近接攻撃画像座標の宣言
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.X += 50;

                // ハックモン1Pの遠距離攻撃画像座標の宣言
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.X += 50;



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
                hackmon1P.position.X -= walkSpeed;
                //aが押されたらハックモン1Pの名前が左に移動
                hackmon1P.namePosition.X -= walkSpeed;


                // ハックモン1Pの近接攻撃画像座標を移動方向に向ける
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.X -= 80;

                // ハックモン1Pの遠距離攻撃画像座標の宣言
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.X -= 50;


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
                hackmon1P.position.Y += walkSpeed;
                //sが押されたらハックモン1Pの名前が下に移動
                hackmon1P.namePosition.Y += walkSpeed;


                // ハックモン1Pの近接攻撃画像座標を移動方向に向ける
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.Y += 50;

                // ハックモン1Pの遠距離攻撃画像座標の宣言
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.Y += 50;


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
                hackmon1P.position.Y -= walkSpeed;
                //wが押されたらハックモン1Pの名前が上に移動
                hackmon1P.namePosition.Y -= walkSpeed;

                // ハックモン1Pの近接攻撃画像座標を移動方向に向ける
                hackmon1P.jabPosition = hackmon1P.position;
                hackmon1P.jabPosition.Y -= 80;

                // ハックモン1Pの遠距離攻撃画像座標の宣言
                hackmon1P.longRangeAttackPosition = hackmon1P.position;
                hackmon1P.longRangeAttackPosition.Y -= 50;



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

            //ハックモン1Pが画面外へ出ないようにする
            if (hackmon1P.position.X <= 0) hackmon1P.position.X = 0;
            if (hackmon1P.position.X >= 800 - 65) hackmon1P.position.X = 800 - 65;
            if (hackmon1P.position.Y <= 0) hackmon1P.position.Y = 0;
            if (hackmon1P.position.Y >= 600 - 180) hackmon1P.position.Y = 600 - 180;



            //方向キーでハックモン2Pを移動
            //左が押されたらX座標を4ピクセル減算する
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                hackmon2P.position.X -= walkSpeed;
                // ハックモン2Pの近接攻撃画像座標の宣言
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.X -= 80;



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
                hackmon2P.position.X += walkSpeed;
                // ハックモン2Pの近接攻撃画像座標を移動方向に向ける
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.X += 50;


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
                hackmon2P.position.Y += walkSpeed;
                // ハックモン2Pの近接攻撃画像座標を移動方向に向ける
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.Y += 50;


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
                hackmon2P.position.Y -= walkSpeed;
                // ハックモン2Pの近接攻撃画像座標を移動方向に向ける
                hackmon2P.jabPosition = hackmon2P.position;
                hackmon2P.jabPosition.Y -= 80;


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
            Rectangle darkTechBackgroundCollider = new Rectangle(0, 0, 800, 600);
            spriteBatch.Draw(darkTechBackground, new Rectangle(0, 0, 800, 600), Color.White);
            //背景画像dark-tech-backgroundの当たり判定を特定する半透明の緑色の矩形を描画
            spriteBatch.Draw(ColliderChecker, new Vector2(0,0), new Rectangle(0, 0, 800, 600), Color.Blue * 0.5f);


            //ハックモン1Pの画像を描画
            spriteBatch.Draw(hackmon1P.image, hackmon1P.position, new Rectangle(hackmon1PFrame * 65, 0, 65, 65), Color.White);
            //ハックモン1Pの当たり判定を特定する半透明の緑色の矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon1P.position, new Rectangle(hackmon1PFrame * 65, 0, 65, 65), Color.Green * 0.5f);
            // ハックモン1PのHPBar画像を描画
            spriteBatch.Draw(HPBarForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // ハックモン1PのHPGauge画像を描画
            int castForHPwidthForhackmon1P;
            castForHPwidthForhackmon1P = (int)HPwidthForhackmon1P;
            spriteBatch.Draw(HPGaugeForHackmon1P, new Vector2(20, 20), new Rectangle(0, 0, castForHPwidthForhackmon1P, 20), Color.White);
            //Spaceでハックモン1Pの近接攻撃攻撃
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                // ハックモン1Pの近接攻撃画像描画
                //Rectangleはintを取るメソッドなのでキャストでfloatをintに変換
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
                //ハックモン1Pが近接攻撃したときにハックモン2Pに当たったらハックモン2Pにダメージ
                if (hackmon1PjabCollider.Intersects(hackmon2PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon2P -= 10.0f ;
                }
            }
            //ハックモン１Pの近接攻撃の当たり判定を特定する半透明の赤い矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon1P.jabPosition, new Rectangle(0, 0, 90, 90), Color.Yellow * 0.5f);
           
            
            //fでハックモン1Pの遠距離攻撃攻撃
            if (KeyboardState.IsKeyDown(Keys.F))
            {
                // ハックモン1Pの遠距離攻撃画像描画
                //Rectangleはintを取るメソッドなのでキャストでfloatをintに変換
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

                        

                    //どうやったら遠距離攻撃が放たれた位置から直線に一定スピードでまっすぐ飛ぶ？

                    //1回fが押されたらhackmon1PlongRangeAttackPositionにハックモンの進行方向に
                    //向かってx軸、y軸にそれぞれ計算がされて画面外まで遠距離攻撃が飛ぶ


                }

                //どうやったらハックモン1Pの遠距離攻撃が表示画面外まで表示され続ける？

                //fボタンを押したら右方向にf長押しで遠距離攻撃が打てるようになった（fボタンを離したら遠距離攻撃が消える）
                //f押して一回移動しないと再度遠距離攻撃が打てない
                //fで遠距離攻撃を1回打って、移動しないで再度遠距離攻撃を撃つと前打ったところから遠距離攻撃
                //が発生して右方向へ飛んでいく
                //ただfを押して、一回遠距離攻撃を撃ったら、画面外に出るまで遠距離攻撃が継続して
                //ハックモン1Pの進行方向に向かって移動していくようにする
                if (hackmon1PlongRangeAttackCollider.Intersects(darkTechBackgroundCollider))
                {
                    hackmon1P.longRangeAttackPosition.X += 20;
                }




                //ハックモン1Pが遠距離攻撃したときにハックモン2Pに当たったらハックモン2Pにダメージ
                if (hackmon1PlongRangeAttackCollider.Intersects(hackmon2PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon2P -= 10.0f;
                }
            }
            //ハックモン１Pの遠距離攻撃の当たり判定を特定する半透明の赤い矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon1P.longRangeAttackPosition, new Rectangle(0, 0, 90, 90), Color.Red * 0.5f);


            //ハックモン1Pの名前を描画
            spriteBatch.Draw(hackmon1P.name, hackmon1P.namePosition, new Rectangle(0, 0, 170, 30), Color.White);


            //ハックモン2Pの画像を描画
            spriteBatch.Draw(hackmon2P.image, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.White);
            //ハックモン2Pの当たり判定を特定する半透明の緑色の矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon2P.position, new Rectangle(hackmon2PFrame * 65, 0, 65, 65), Color.Green * 0.5f);
            // ハックモン2PのHPBar画像の宣言
            spriteBatch.Draw(HPBarForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, 250, 20), Color.White);
            // ハックモン2PのHPGauge画像の宣言
            int castForHPwidthForhackmon2P;
            castForHPwidthForhackmon2P = (int)HPwidthForhackmon2P;
            spriteBatch.Draw(HPGaugeForHackmon2P, new Vector2(530, 20), new Rectangle(0, 0, castForHPwidthForhackmon2P, 20), Color.White);
            //Enterでハックモン2Pの近接攻撃攻撃
            if (KeyboardState.IsKeyDown(Keys.Enter))
            {
                // ハックモン2Pの近接攻撃画像描画
                //Rectangleはintを取るメソッドなのでキャストでfloatをintに変換
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
                //ハックモン2Pが近接攻撃したときにハックモン1Pに当たったらハックモン2Pにダメージ
                if (hackmon2PjabCollider.Intersects(hackmon1PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon1P -= 10.0f;
                }
            }
            //ハックモン2Pの近接攻撃の当たり判定を特定する半透明の赤い矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon2P.jabPosition, new Rectangle(0, 0, 90, 90), Color.Red * 0.5f);



            //fでハックモン2Pの遠距離攻撃攻撃
            if (KeyboardState.IsKeyDown(Keys.L))
            {
                // ハックモン1Pの遠距離攻撃画像描画
                //Rectangleはintを取るメソッドなのでキャストでfloatをintに変換
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



                    //どうやったら遠距離攻撃が放たれた位置から直線に一定スピードでまっすぐ飛ぶ？

                    //1回fが押されたらhackmon2PlongRangeAttackPositionにハックモンの進行方向に
                    //向かってx軸、y軸にそれぞれ計算がされて画面外まで遠距離攻撃が飛ぶ


                }

                //どうやったらハックモン1Pの遠距離攻撃が表示画面外まで表示され続ける？

                //fボタンを押したら右方向にf長押しで遠距離攻撃が打てるようになった（fボタンを離したら遠距離攻撃が消える）
                //f押して一回移動しないと再度遠距離攻撃が打てない
                //fで遠距離攻撃を1回打って、移動しないで再度遠距離攻撃を撃つと前打ったところから遠距離攻撃
                //が発生して右方向へ飛んでいく
                //ただfを押して、一回遠距離攻撃を撃ったら、画面外に出るまで遠距離攻撃が継続して
                //ハックモン2Pの進行方向に向かって移動していくようにする
                if (hackmon2PlongRangeAttackCollider.Intersects(darkTechBackgroundCollider))
                {
                    hackmon2P.longRangeAttackPosition2.X -= 10;
                }




                //ハックモン2Pが遠距離攻撃したときにハックモン1Pに当たったらハックモン1Pにダメージ
                if (hackmon2PlongRangeAttackCollider.Intersects(hackmon1PimageCollider))
                {
                    float damage;
                    damage = HPwidthForhackmon1P -= 8.0f;
                }
            }
            //ハックモン2Pの遠距離攻撃の当たり判定を特定する半透明の赤い矩形を描画
            spriteBatch.Draw(ColliderChecker, hackmon2P.longRangeAttackPosition, new Rectangle(0, 0, 190, 190), Color.Red * 0.5f);




            //次の機能

            //ハックモン１Pかハックモン2PのどちらかのHPが0になったらゲームが終わって
            //Exitするかゲームを再開できる
            //どうやって再開する？
            //→体力ゲージとハックモンの位置をスタート時に戻す

            if (HPwidthForhackmon1P <= 0 || HPwidthForhackmon2P <= 0)
            {
                spriteBatch.Draw(Complete, new Vector2(300, 300), new Rectangle(0, 0, 500, 100), Color.White);
                walkSpeed = 1;　//HPが0になった後に移動するとフレームレートが落ちてゲームを
                //もう一度始める時間が遅くなる

                frame++;
                //ゲームをもう一度やるまでの余韻の時間
                if (frame >= 60)
                {
                    //ゲームをもう一度やる
                    Initialize();

                    spriteBatch.Begin();

                    //回数をクリア
                    frame = 0;
                }

                




                //Console.WriteLine("モウヒトショウブする？:y/n");
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
