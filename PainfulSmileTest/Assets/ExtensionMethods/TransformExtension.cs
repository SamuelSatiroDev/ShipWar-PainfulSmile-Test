using UnityEngine;

namespace ExtensionMethods
{
    public static class TransformExtension
    {

        #region KeepOnCamera
        public static void KeepOnCamera(this Transform myTransform)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(myTransform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            myTransform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        #endregion

        #region RandomPositionOnCameraEdges
        public static void RandomPositionOnCameraEdges(this Transform transform, Vector4 offset, EnumManager.ScreenEdge SideOfTheScreen)
        {
            if (Camera.main == null)
                return;

            var _distance = (transform.position - Camera.main.transform.position).z;

            var _leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, _distance)).x + (offset.x);
            var _rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, _distance)).x - (offset.y);

            var _upBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, _distance)).y - (offset.z);
            var _downBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, _distance)).y + (offset.w);


            int newPositionY = (int)Random.Range(_downBorder, _upBorder);
            int newPositionX = (int)Random.Range(_leftBorder, _rightBorder);
            Vector3 newPosition = Vector3.zero;


            switch (SideOfTheScreen)
            {
                case EnumManager.ScreenEdge.Left:
                    newPosition = new Vector3(_leftBorder, newPositionY, transform.position.z);
                    break;

                case EnumManager.ScreenEdge.Right:
                    newPosition = new Vector3(_rightBorder, newPositionY, transform.position.z);
                    break;

                case EnumManager.ScreenEdge.Up:
                    newPosition = new Vector3(newPositionX, _upBorder, transform.position.z);
                    break;

                case EnumManager.ScreenEdge.Down:
                    newPosition = new Vector3(newPositionX, _downBorder, transform.position.z);
                    break;   
            }

            transform.position = newPosition;
        }
        #endregion

        #region LookAt2D
        public static void LookAt2D(this Transform transform, Transform target, EnumManager.Direction direction)
        {
            if (target == null)
                return;


            switch (direction)
            {
                case EnumManager.Direction.Right:
                    transform.rotation = Quaternion.LookRotation(target.position, transform.up) * Quaternion.Euler(new Vector3(0, -90, 0));
                    break;

                case EnumManager.Direction.Up:
                    Vector3 norTar = (target.position - transform.position).normalized;
                    float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
                    Quaternion rotation = new Quaternion();
                    rotation.eulerAngles = new Vector3(0, 0, angle - 90);
                    transform.rotation = rotation;
                    break;
            }
        }
        #endregion
    }
}