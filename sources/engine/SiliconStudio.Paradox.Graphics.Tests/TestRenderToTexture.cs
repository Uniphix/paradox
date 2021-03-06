﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Games;

namespace SiliconStudio.Paradox.Graphics.Tests
{
    [TestFixture]
    class TestRenderToTexture : TestGameBase
    {
        private RenderTarget offlineTarget0;
        private RenderTarget offlineTarget1;
        private RenderTarget offlineTarget2;
        private DepthStencilBuffer depthBuffer;
        private Matrix worldViewProjection;
        private GeometricPrimitive geometry;
        private SimpleEffect simpleEffect;
        private bool firstSave;

        private int width;
        private int height;

        public TestRenderToTexture()
        {
            CurrentVersion = 1;
        }

        protected override void RegisterTests()
        {
            base.RegisterTests();

            FrameGameSystem.Draw(RenderToTexture).TakeScreenshot();
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();

            var view = Matrix.LookAtRH(new Vector3(2,2,2), new Vector3(0, 0, 0), Vector3.UnitY);
            var projection = Matrix.PerspectiveFovRH((float)Math.PI / 4.0f, (float)GraphicsDevice.BackBuffer.Width / GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            worldViewProjection = Matrix.Multiply(view, projection);

            geometry = GeometricPrimitive.Cube.New(GraphicsDevice);
            simpleEffect = new SimpleEffect(GraphicsDevice) { Texture = UVTexture };
            
            // TODO DisposeBy is not working with device reset
            offlineTarget0 = Texture2D.New(GraphicsDevice, 512, 512, PixelFormat.R8G8B8A8_UNorm, TextureFlags.ShaderResource | TextureFlags.RenderTarget).DisposeBy(this).ToRenderTarget().DisposeBy(this);

            offlineTarget1 = Texture2D.New(GraphicsDevice, 512, 512, PixelFormat.R8G8B8A8_UNorm, TextureFlags.ShaderResource | TextureFlags.RenderTarget).DisposeBy(this).ToRenderTarget().DisposeBy(this);
            offlineTarget2 = Texture2D.New(GraphicsDevice, 512, 512, PixelFormat.R8G8B8A8_UNorm, TextureFlags.ShaderResource | TextureFlags.RenderTarget).DisposeBy(this).ToRenderTarget().DisposeBy(this);

            depthBuffer = Texture2D.New(GraphicsDevice, 512, 512, PixelFormat.D16_UNorm, TextureFlags.DepthStencil).DisposeBy(this).ToDepthStencilBuffer(false).DisposeBy(this);

            width = GraphicsDevice.BackBuffer.Width;
            height = GraphicsDevice.BackBuffer.Height;
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if(!ScreenShotAutomationEnabled)
                RenderToTexture();

            if (firstSave)
            {
                SaveTexture(UVTexture, "a_uvTex.png");
                SaveTexture(offlineTarget0.Texture, "a_firstRT.png");
                SaveTexture(offlineTarget2.Texture, "a_secondRT.png");
                firstSave = false;
            }
        }

        private void RenderToTexture()
        {
            GraphicsDevice.Clear(GraphicsDevice.BackBuffer, Color.Black);
            GraphicsDevice.Clear(GraphicsDevice.DepthStencilBuffer, DepthStencilClearOptions.DepthBuffer);
            GraphicsDevice.Clear(offlineTarget0, Color.Black);
            GraphicsDevice.Clear(offlineTarget1, Color.Black);
            GraphicsDevice.Clear(offlineTarget2, Color.Black);

            // direct render
            GraphicsDevice.SetRenderTarget(GraphicsDevice.DepthStencilBuffer, GraphicsDevice.BackBuffer);
            GraphicsDevice.SetViewport(new Viewport(0, 0, width / 2, height / 2));
            DrawGeometry();

            // 1 intermediate RT
            GraphicsDevice.Clear(depthBuffer, DepthStencilClearOptions.DepthBuffer);
            GraphicsDevice.SetRenderTarget(depthBuffer, offlineTarget0);
            DrawGeometry();

            GraphicsDevice.SetRenderTarget(GraphicsDevice.DepthStencilBuffer, GraphicsDevice.BackBuffer);
            GraphicsDevice.SetViewport(new Viewport(width / 2, 0, width / 2, height / 2));
            GraphicsDevice.DrawTexture(offlineTarget0.Texture);

            // 2 intermediate RTs
            GraphicsDevice.Clear(depthBuffer, DepthStencilClearOptions.DepthBuffer);
            GraphicsDevice.SetRenderTarget(depthBuffer, offlineTarget1);
            DrawGeometry();

            GraphicsDevice.Clear(depthBuffer, DepthStencilClearOptions.DepthBuffer);
            GraphicsDevice.SetRenderTarget(depthBuffer, offlineTarget2);
            GraphicsDevice.DrawTexture(offlineTarget1.Texture);

            GraphicsDevice.SetRenderTarget(GraphicsDevice.DepthStencilBuffer, GraphicsDevice.BackBuffer);
            GraphicsDevice.SetViewport(new Viewport(0, height / 2, width / 2, height / 2));
            GraphicsDevice.DrawTexture(offlineTarget2.Texture);

            // draw quad on screen
            GraphicsDevice.SetRenderTarget(GraphicsDevice.DepthStencilBuffer, GraphicsDevice.BackBuffer);
            GraphicsDevice.SetViewport(new Viewport(width / 2, height / 2, width / 2, height / 2));
            GraphicsDevice.DrawTexture(UVTexture);
        }

        private void DrawGeometry()
        {
            simpleEffect.Transform = worldViewProjection;
            simpleEffect.Apply();
            geometry.Draw();
        }

        public static void Main()
        {
            using (var game = new TestRenderToTexture())
                game.Run();
        }

        /// <summary>
        /// Run the test
        /// </summary>
        [Test]
        public void RunRenderToTexture()
        {
            RunGameTest(new TestRenderToTexture());
        }
    }
}
