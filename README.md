# Open VSIX Gallery

An Open VSIX Gallery to supercharge your Visual Studio with extensions !🚀🔌👩‍💻

# DockerHub
[DockerHub Repo](https://hub.docker.com/r/redbeardjdl/vsixgallery)

# Docker Container Documentation

## Configuration

### 1. Environment Variables
You can configure the container using the following environment variables:

| Variable Name                          | Description                                                   | Default Value         |
|----------------------------------------|---------------------------------------------------------------|-----------------------|
| `Extensions__RemoveOldExtensions`      | Controls whether old extensions should be removed.            | `true`                |
| `Display__SiteName`                    | Sets the display name of the site.                            | `Open VSIX Gallery`   |
| `Display__HideSetupLink`               | Hides the setup link on the site if set to `true`.            | `false`               |
| `Display__HideUploadGuideLink`         | Hides the upload guide link on the site if set to `true`.     | `false`               |
| `Display__HideCreateExtensionLink`     | Hides the create extension link on the site if set to `true`. | `false`               |
| `Display__HideContributeLink`          | Hides the contribute link on the site if set to `true`.       | `false`               |
| `Upload__SecretKey`                    | Secret key used for securing uploads.                         |                       |

#### Example
To set environment variables, use the `-e` flag when running the container:

```bash
docker run -e Extensions__RemoveOldExtensions=false -e Display__HideSetupLink=true redbeardjdl/vsixgallery:tag
```

---

### 2. Exposed Port
This container listens on the following port:

| Port   | Protocol | Description               |
|--------|----------|---------------------------|
| `5000` | `TCP`    | Main application endpoint |

#### Example
To bind the container port to your host, use the `-p` flag:

```bash
docker run -p 8080:5000 redbeardjdl/vsixgallery:tag
```

After running the container, the application will be accessible at `http://localhost:8080`.

---

### 3. Volumes
The container uses the following volumes for data persistence or configuration:

| Container Path               | Description                     |
|------------------------------|---------------------------------|
| `/app/wwwroot/extensions`    | Stores extensions data.         |

#### Example
To mount volumes, use the `-v` flag:

```bash
docker run -v /host/data/extensions:/app/wwwroot/extensions redbeardjdl/vsixgallery:tag
```

---

### Full Example Command

```bash
docker run -d \
  --name vsixgallery \
  -e Extensions__RemoveOldExtensions=false \
  -e Display__SiteName="Custom VSIX Gallery" \
  -e Display__HideSetupLink=true \
  -e Display__HideUploadGuideLink=true \
  -e Display__HideCreateExtensionLink=true \
  -e Display__HideContributeLink=true \
  -e Upload__SecretKey=VSIX_GALLERY_SECRET_KEY \
  -p VSIX_GALLERY_PORT:5000 \
  -v /host/data/extenstons:/app/wwwroot/extensions \
  redbeardjdl/vsixgallery:tag
```

This command:
- Sets the environment variables.
- Maps the container's `5000` port to the host's `5000` port.
- Mounts two host directories to the container's paths.

---

### Push your VSIX Extension

```bash
curl --location 'http://VSIX_GALLERY_HOST:VSIX_GALLERY_PORT/api/upload?repo=YOUR_VSIX_EXTENSION_SOURCE_REPO_URLENCODED' \
--header 'Content-Type: multipart/form-data' \
--header 'Authorization: Bearer VSIX_GALLERY_SECRET_KEY' \
--form '=@"PATH_TO_YOUR_VSIX_FILE"'
```
