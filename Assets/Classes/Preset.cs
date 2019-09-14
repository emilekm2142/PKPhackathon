using UnityEngine;

namespace Classes
{
    public class Preset
    {
        public Color color;
        public Texture2D texture;

        public Preset(Color color, Texture2D texture)
        {
            this.color = color;
            this.texture = texture;
        }
    }
}