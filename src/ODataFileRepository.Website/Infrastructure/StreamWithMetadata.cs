﻿using System;
using System.IO;

namespace ODataFileRepository.Website.Infrastructure
{
    public class StreamWithMetadata : LazyStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LazyStream"/> class.
        /// </summary>
        /// <param name="streamFactory">The <see cref="Func{T}">factory method</see> used to retrieve the underlying <see cref="Stream">stream</see>.</param>
        /// <param name="mediaType">The MIME type of the stream content.</param>
        public StreamWithMetadata(Func<Stream> streamFactory, string mediaType)
            : this(new Lazy<Stream>(streamFactory), mediaType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LazyStream"/> class.
        /// </summary>
        /// <param name="lazyStream">The underlying <see cref="Lazy{T}">on-demand</see> <see cref="Stream">stream</see>.</param>
        /// <param name="mediaType">The MIME type of the stream content.</param>
        public StreamWithMetadata(Lazy<Stream> lazyStream, string mediaType)
            : base(lazyStream)
        {
            if (mediaType == null)
            {
                throw new ArgumentNullException("mimeType");
            }

            MediaType = mediaType;
        }

        public string MediaType { get; private set; }
    }
}