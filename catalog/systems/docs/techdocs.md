# Tanzu Application Platform

You can follow the below steps for generate and publish docs.

```
tap_gui:
    app_config:
        techdocs:
            builder: 'external'
            publisher:
                type: 'awsS3'
                awsS3:
                    bucketName: samplebucketname
                    credentials:
                        accessKeyId: admin
                        secretAccessKey: password
                    region: minio
                    endpoint: http://s3-object-storage-url
                    s3ForcePathStyle: true
```



```
npm install -g npx
npx @techdocs/cli generate --source-dir catalog/systems/ --no-docker --output-dir ./site
mc cp --recursive site/  minio/techdocs/default/system/tanzu-banking-system
```