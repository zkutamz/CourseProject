import React,{useState} from 'react';
import axiosClient from '../../../../api/axiosClient';

function Attachments({onAddLessonAttachments}) {
    const [attachmentUrl, setAttachmentUrl] = useState("");
    const [attachmentUploaded, setattachmentUploaded] = useState(0);
    const [selectedFile, setSelectedFile] = useState(null);
    const [attachmentIsValid, setattachmentIsvalid]= useState(false);
    const [mainState, setMainState] = useState('initial');

    const handleAttachmentClick = (event) => {
        var file = event.target.files[0];
        const reader = new FileReader();
        var url = reader.readAsDataURL(file);

        setMainState('uploaded');
        setSelectedFile(event.target.files[0]);
        setattachmentUploaded(1);
        const formData = new FormData();
        formData.append('file', event.target.files[0]);
        console.log(formData);
        axiosClient.post('/Files/upload-file-to-azure', formData).then((res) => {

        setAttachmentUrl(res.data.data);
        setattachmentIsvalid(true);
        });
      };

      console.log(attachmentIsValid)
if (attachmentIsValid) {
    setattachmentIsvalid(false);
    onAddLessonAttachments({
        attachmentUrl: attachmentUrl
    });
    console.log("run onAddLessonVideo");
  }  
  return (
    <div className="tab-pane fade show active" id="nav-attachment" role="tabpanel">
      <div className="row">
        <div className="col-lg-12">
          <div className="upload-file-dt mt-30">
            <div className="upload-btn">
              <input className="uploadBtn-main-input" type="file" id="SourceFile__input--source" onChange={handleAttachmentClick} />
              <label htmlFor="SourceFile__input--source" title="Zip">
                <i className="far fa-plus-square mr-2" />
                Attachment
              </label>
            </div>
            <span className="uploadBtn-main-file">Supports: jpg, jpeg, png, pdf or .zip</span>
            {/* <div className="add-attachments-dt">
              <div className="attachment-items">
                <div className="attachment_id">Uploaded ID: 12</div>
                <button className="cancel-btn" type="button">
                  <i className="fas fa-trash-alt" />
                </button>
              </div>
              <div className="attachment-items">
                <div className="attachment_id">Uploaded ID: 13</div>
                <button className="cancel-btn" type="button">
                  <i className="fas fa-trash-alt" />
                </button>
              </div>
              <div className="attachment-items">
                <div className="attachment_id">Uploaded ID: 14</div>
                <button className="cancel-btn" type="button">
                  <i className="fas fa-trash-alt" />
                </button>
              </div>
            </div> */}
          </div>
        </div>
      </div>
    </div>
  );
}
export default Attachments;
