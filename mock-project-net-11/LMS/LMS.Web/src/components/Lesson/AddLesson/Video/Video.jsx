import React, {useState} from 'react';
import axiosClient from '../../../../api/axiosClient';
function Video({onAddLessonVideo, myObject}) {

    const [mainState, setMainState] = useState('initial');
    const [imageUploaded, setImageUploaded] = useState(0);
    const [videoUploaded, setVideoUploaded] = useState(0);
    const [selectedFile, setSelectedFile] = useState(null);
    const [iUrl, setIUrl] = useState(myObject.imageUrl);
    const [videoUrl, setVideoUrl] = useState(myObject.videoUrl);
    const [videoIsValid, setVideoIsvalid]= useState(false);
    const [imageIsvalid, setImageIsvalid] = useState(false);
    const handleUploadImageClick = (event) => {
        var file = event.target.files[0];
        const reader = new FileReader();
        var url = reader.readAsDataURL(file);

        setMainState('uploaded');
        setSelectedFile(event.target.files[0]);
        setImageUploaded(1);
        const formData = new FormData();
        formData.append('file', event.target.files[0]);
        console.log(formData);
        axiosClient.post('/Files/upload-file-to-azure', formData).then((res) => {

        setIUrl(res.data.data);
        setImageIsvalid(true);
        });
      };
      const handleUploadVideoClick = (event) => {
        var file = event.target.files[0];
        const reader = new FileReader();
        var url = reader.readAsDataURL(file);
    
        setMainState('uploaded');
        setSelectedFile(event.target.files[0]);
        setVideoUploaded(1);
        const formData = new FormData();
        formData.append('file', event.target.files[0]);
        console.log(formData);
        axiosClient.post('/Files/upload-file-to-azure', formData).then((res) => {

        setVideoUrl(res.data.data);
        setVideoIsvalid(true);
        });
      };

console.log(videoIsValid +" "+imageIsvalid)
if (videoIsValid && imageIsvalid) {
    setImageIsvalid(false);
    setVideoIsvalid(false);
    onAddLessonVideo({
        imageUrl: iUrl, 
        videoUrl: videoUrl
    });
    console.log("run onAddLessonVideo");
  }  
  return (
    <div className="tab-pane fade show active" id="nav-video" role="tabpanel">
      <div className="lecture-video-dt mt-30">
        <span className="video-info">
          Select your preferred video type. (.mp4, YouTube, Vimeo etc.)
        </span>
        <div className="video-category">
          <label>
            <input type="radio" name="colorRadio" defaultValue="mp4" defaultChecked />
            <span>HTML5(mp4)</span>
          </label>
          <label>
            <input type="radio" name="colorRadio" defaultValue="url" />
            <span>External URL</span>
          </label>
          <label>
            <input type="radio" name="colorRadio" defaultValue="youtube" />
            <span>YouTube</span>
          </label>
          <label>
            <input type="radio" name="colorRadio" defaultValue="vimeo" />
            <span>Vimeo</span>
          </label>
          <label>
            <input type="radio" name="colorRadio" defaultValue="embedded" />
            <span>embedded</span>
          </label>
          <div className="mp4 video-box" style={{ display: 'block' }}>
            <div className="row">
              <div className="col-lg-6 col-md-6">
                <div className="upload-file-dt mt-30">
                  <div className="upload-btn">
                    <input
                      className="uploadBtn-main-input"
                      type="file"
                      id="VideoFile__input--source"
                      onChange={handleUploadVideoClick}
                    />
                    <label htmlFor="VideoFile__input--source" title="Zip">
                      Upload Video
                    </label>
                  </div>
                  <span className="uploadBtn-main-file">File Format: .mp4</span>
                </div>
              </div>
              <div className="col-lg-6 col-md-6">
                <div className="upload-file-dt mt-30">
                  <div className="upload-btn">
                    <input
                      className="uploadBtn-main-input"
                      type="file"
                      id="PosterFile__input--source"
                      onChange={handleUploadImageClick}
                    />
                    <label htmlFor="PosterFile__input--source" title="Zip">
                      Video Poster
                    </label>
                  </div>
                  <span className="uploadBtn-main-file color-b">Uploaded ID : preview.jpg</span>
                  <span className="uploaded-id color-fmt">
                    Size: 590x300 pixels. Supports: jpg,jpeg, or png
                  </span>
                </div>
              </div>
            </div>
            {/* <div className="video-duration">
                                  <label className="label25">
                                    Video Runtime -<strong>hh:mm:ss</strong>*
                                  </label>
                                  <div className="duration-time">
                                    <div className="input-group">
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][hours]"
                                        defaultValue={00}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][mins]"
                                        defaultValue={1}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][secs]"
                                        defaultValue={00}
                                      />
                                    </div>
                                  </div>
                                </div> */}
          </div>
          <div className="url video-box">
            <div className="new-section">
              <div className="ui search focus mt-30 lbel25">
                <label>External URL*</label>
                <div className="ui left icon input swdh19">
                  <input
                    className="prompt srch_explore"
                    type="text"
                    placeholder="External Video URL"
                    name
                    id
                    defaultValue
                  />
                </div>
              </div>
            </div>
            {/* <div className="video-duration">
                                  <label className="label25">
                                    Video Runtime -<strong>hh:mm:ss</strong>*
                                  </label>
                                  <div className="duration-time">
                                    <div className="input-group">
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][hours]"
                                        defaultValue={00}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][mins]"
                                        defaultValue={1}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][secs]"
                                        defaultValue={00}
                                      />
                                    </div>
                                  </div>
                                </div> */}
          </div>
          <div className="youtube video-box">
            <div className="new-section">
              <div className="ui search focus mt-30 lbel25">
                <label>Youtube URL*</label>
                <div className="ui left icon input swdh19">
                  <input
                    className="prompt srch_explore"
                    type="text"
                    placeholder="Youtube Video URL"
                    name
                    id
                    defaultValue
                  />
                </div>
              </div>
            </div>
            {/* <div className="video-duration">
                                  <label className="label25">
                                    Video Runtime -<strong>hh:mm:ss</strong>*
                                  </label>
                                  <div className="duration-time">
                                    <div className="input-group">
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][hours]"
                                        defaultValue={00}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][mins]"
                                        defaultValue={1}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][secs]"
                                        defaultValue={00}
                                      />
                                    </div>
                                  </div>
                                </div> */}
          </div>
          <div className="vimeo video-box">
            <div className="new-section">
              <div className="ui search focus mt-30 lbel25">
                <label>Vimeo URL*</label>
                <div className="ui left icon input swdh19">
                  <input
                    className="prompt srch_explore"
                    type="text"
                    placeholder="Vimeo Video URL"
                    name
                    id
                    defaultValue
                  />
                </div>
              </div>
            </div>
            {/* <div className="video-duration">
                                  <label className="label25">
                                    Video Runtime -<strong>hh:mm:ss</strong>*
                                  </label>
                                  <div className="duration-time">
                                    <div className="input-group">
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][hours]"
                                        defaultValue={00}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][mins]"
                                        defaultValue={1}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][secs]"
                                        defaultValue={00}
                                      />
                                    </div>
                                  </div>
                                </div> */}
          </div>
          <div className="embedded video-box">
            <div className="new-section">
              <div className="ui search focus mt-30 lbel25">
                <label>Embedded Code*</label>
                <div className="ui form swdh30">
                  <div className="field">
                    <textarea
                      rows={3}
                      name
                      id
                      placeholder="Place your embedded code here"
                      defaultValue={''}
                    />
                  </div>
                </div>
              </div>
            </div>
            {/* <div className="video-duration">
                                  <label className="label25">
                                    Video Runtime -<strong>hh:mm:ss</strong>*
                                  </label>
                                  <div className="duration-time">
                                    <div className="input-group">
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][hours]"
                                        defaultValue={00}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][mins]"
                                        defaultValue={1}
                                      />
                                      <input
                                        type="text"
                                        className="form_input_1"
                                        name="video[runtime][secs]"
                                        defaultValue={00}
                                      />
                                    </div>
                                  </div>
                                </div> */}
          </div>
        </div>
      </div>
    </div>
  );
}
export default Video;
