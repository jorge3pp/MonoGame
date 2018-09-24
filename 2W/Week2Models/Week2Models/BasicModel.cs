using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Week2Models
{
    public class BasicModel
    {
        public Model model;
        public Matrix[] bonesTransforms;
        public Matrix world;

        private string asset;

        public BasicModel(string asset, Vector3 position, Vector3 rotation, Vector3 scale){

            this.asset = asset;

            world = Matrix.Identity *
                Matrix.CreateScale(scale) *
                Matrix.CreateRotationX(rotation.X) *
                Matrix.CreateRotationY(rotation.Y) *
                Matrix.CreateRotationZ(rotation.Z) *
                Matrix.CreateTranslation(position);

        }

        public void LoadContent(ContentManager content)
        {
            model = content.Load<Model>("Models\\"+asset);
            bonesTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(bonesTransforms);

        }

        public void Draw(Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = view;
                    effect.Projection = projection;
                    effect.World = bonesTransforms[mesh.ParentBone.Index] * world;

                    //effect.PreferPerPixelLighting = true;
                    //effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }
    }
}
