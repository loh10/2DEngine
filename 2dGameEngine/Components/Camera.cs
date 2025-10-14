using Components;
using Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Scripts;

public class Camera
{
    public Vector2 position;
    private float _zoom;
    public float rotation;
    public Matrix matrix;
    private Entity _entity = null;
    private Viewport _viewport;
    public float Zoom
    {
        get => _zoom;
        set => _zoom = MathHelper.Clamp(value, 0.1f, 4f);
    }
    public Camera(Viewport _viewport)
    {
        this._viewport = _viewport;
        _zoom = 1f;
        rotation = 0f;
        position = Vector2.Zero;
    }

    /// <summary>
    /// Follow Entity
    /// </summary>
    public void Follow(Entity _target)
    {
        _entity = _target;
    }

    /// <summary>
    /// Déplacer manuellement la caméra
    /// </summary>
    public void Move(Vector2 _delta)
    {
        position += _delta;
    }

    /// <summary>
    /// Return Transform matrix to SpriteBatch
    /// </summary>
    public Matrix GetViewMatrix()
    {
        Vector2 origin = new Vector2(_viewport.Width / 2f, _viewport.Height / 2f);

        if (_entity?.GetComponent<Transform>() != null)
        {
            position = _entity.GetComponent<Transform>()!.Position;
        }

        return
            Matrix.CreateTranslation(new Vector3(-position, 0f)) *
            Matrix.CreateRotationZ(rotation) *
            Matrix.CreateScale(_zoom, _zoom, 1f) *
            Matrix.CreateTranslation(new Vector3(origin, 0f));
    }

    /// <summary>
    /// Convert screen pos to world pos
    /// </summary>
    public Vector2 ScreenToWorld(Vector2 _screenPosition)
    {
        return Vector2.Transform(_screenPosition - new Vector2(_viewport.Width / 2f, _viewport.Height / 2f),
            Matrix.Invert(Matrix.CreateRotationZ(rotation) * Matrix.CreateScale(_zoom))) + position;
    }

    /// <summary>
    /// Convert world pos to screen pos
    /// </summary>
    public Vector2 WorldToScreen(Vector2 _worldPosition)
    {
        return Vector2.Transform(_worldPosition - position,
                   Matrix.CreateScale(_zoom) * Matrix.CreateRotationZ(rotation)) +
               new Vector2(_viewport.Width / 2f, _viewport.Height / 2f);
    }
}