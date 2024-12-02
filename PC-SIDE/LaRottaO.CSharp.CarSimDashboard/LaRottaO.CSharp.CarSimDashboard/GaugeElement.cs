using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaRottaO.CSharp.CarSimDashboard
{
    internal class GaugeElement
    {
        private PictureBox needlePictureBox;
        private Bitmap originalImage;
        private float currentValue = 0;
        private int needleRotationSpeedMultiplier = 2;
        private List<Tuple<float, float>> correctionPoints;

        private Boolean needleIsOnTheMove = false;
        private Boolean needleBrake = false;

        public GaugeElement(PictureBox needlePictureBox, List<Tuple<float, float>> correctionPoints, int needleRotationSpeed)
        {
            this.originalImage = new Bitmap(needlePictureBox.Image);
            this.correctionPoints = correctionPoints;
            this.needlePictureBox = needlePictureBox;
            this.needleRotationSpeedMultiplier = needleRotationSpeed;

            applyNeedleAngle(0);
        }

        public void inputNewValue(float newTargetValue)
        {
            if (newTargetValue < float.MinValue || newTargetValue > float.MaxValue)
            {
                return;
            }

            if (needleIsOnTheMove)
            {
                needleBrake = true;
            }

            rotateNeedleToNewValue(newTargetValue);
        }

        public void rotateNeedleToNewValue(float newTargetValue)
        {
            if (newTargetValue > currentValue)
            {
                while (currentValue < newTargetValue && !needleBrake)
                {
                    {
                        needleIsOnTheMove = true;
                        applyNeedleAngle(currentValue); 
                        currentValue += needleRotationSpeedMultiplier;
                    }
                }

                needleIsOnTheMove = false;
                needleBrake = false;
            }
            else if (newTargetValue < currentValue)
            {
                while (currentValue > newTargetValue && !needleBrake)
                {
                    needleIsOnTheMove = true;
                    applyNeedleAngle(currentValue); 
                    currentValue -= needleRotationSpeedMultiplier;
                }

                needleIsOnTheMove = false;
                needleBrake = false;
            }
        }

        private void applyNeedleAngle(float newTargetValue)
        {
            try
            {
                // Interpolate the angle for the given value
                float angle = InterpolateAngle(newTargetValue);

                // Create a new bitmap for the rotated image
                Bitmap rotatedImage = new Bitmap(originalImage.Width, originalImage.Height);

                using (Graphics g = Graphics.FromImage(rotatedImage))
                {
                    g.Clear(Color.Transparent); // Ensure the background is transparent
                    g.TranslateTransform(originalImage.Width / 2, originalImage.Height / 2); // Set pivot point
                    g.RotateTransform(angle); // Rotate by the interpolated angle
                    g.TranslateTransform(-originalImage.Width / 2, -originalImage.Height / 2); // Reset pivot point
                    g.DrawImage(originalImage, 0, 0); // Draw rotated image
                }

                // Update the PictureBox with the rotated image
                needlePictureBox.Image = rotatedImage;
                needlePictureBox.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private float InterpolateAngle(float value)
        {
            // Find the two correction points between which the value lies
            Tuple<float, float> lowerPoint = null, upperPoint = null;

            for (int i = 0; i < correctionPoints.Count - 1; i++)
            {
                if (value >= correctionPoints[i].Item1 && value <= correctionPoints[i + 1].Item1)
                {
                    lowerPoint = correctionPoints[i];
                    upperPoint = correctionPoints[i + 1];
                    break;
                }
            }

            if (lowerPoint == null || upperPoint == null)
            {
                throw new InvalidOperationException("Value is out of interpolation bounds.");
            }

            // Perform linear interpolation
            float t = (value - lowerPoint.Item1) / (upperPoint.Item1 - lowerPoint.Item1); // Fraction between points
            return lowerPoint.Item2 + t * (upperPoint.Item2 - lowerPoint.Item2);          // Interpolated angle
        }
    }
}