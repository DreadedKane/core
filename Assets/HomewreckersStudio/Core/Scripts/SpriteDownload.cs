﻿/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using System.Collections;
using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Downloads an image and creates a sprite from it.
     */
    public sealed class SpriteDownload : MonoBehaviour
    {
        /** Used to invoke callbacks. */
        private Request m_request;

        /** Created when the image has downloaded. */
        private Sprite m_sprite;

        /**
         * Creates the request object.
         */
        private void Awake()
        {
            m_request = new Request();
        }

        /**
         * Gets the downloaded sprite.
         */
        public Sprite Sprite
        {
            get
            {
                return m_sprite;
            }
        }
        /**
         * Starts downloading the sprite.
         */
        public void Download(string url, Action success, Action failure)
        {
            m_request.SetListeners(success, failure);

            if (m_sprite == null)
            {
                StartCoroutine(Coroutine(url));
            }
            else
            {
                m_request.OnSuccess();
            }
        }

        /**
         * Downloads the image and creates a sprite.
         */
        private IEnumerator Coroutine(string url)
        {
            // Downloads the image
            WWW www = new WWW(url);

            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                // Creates the sprite
                Texture2D texture = www.texture;
                Rect rect = new Rect(0f, 0f, texture.width, texture.height);
                Vector2 pivot = new Vector2(.5f, .5f);

                m_sprite = Sprite.Create(texture, rect, pivot);

                m_request.OnSuccess();
            }
            else
            {
                // Logs a warning
                Debug.LogWarning("Sprite download failed: " + www.error);

                m_request.OnFailure();
            }
        }
    }
}
