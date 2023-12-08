//create an interface IBlobStorageService with a method that saves a file to azure blob service.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace EshopOnAI.ProductGenerator.Services 
{
    public interface IBlobStorageService
    {
        Task<Uri> UploadFileToBlobAsync(string filePath, string fileName);
    }

    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public BlobStorageService(IConfiguration configuration, BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            _containerName = configuration["BlobStorage:ContainerName"];
        }

        public async Task<Uri> UploadFileToBlobAsync(string filePath, string fileName)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = "image/png" });
            return blobClient.Uri;
        }
    }
}

