import React, {useState,useEffect} from 'react';
import { Route, Switch } from 'react-router-dom';
import axiosClient from '../../../api/axiosClient';
import Footer from '../AddLesson/Footer/Footer';
import Attachments from './Attachments/Attachments';
import Basic from './Basic/Basic';
import Tabs from './Tabs/Tabs';
import Video from './Video/Video';


function AddLesson() {

    const [myObject, setMyObject] = useState({
        title: "",
        content: "",
        imageUrl: "",
        totalTime: 0,
        isPublic: true,
        sectionId: 0,
        embeddedCode: "",
        videoUrl: "",
        attachments: [{
            attachmentUrl: "",
            size: 0,
            isDelete: false
        }],
        externalUrl: "",
        position: 0
      });
      const [clickTab, setClickTab] = useState(false);
      const hanldeClickButtonAddLesson =(check)=>{
        console.log("AddLesson");
        axiosClient.post('/Lessons',myObject).then((res)=>{
            alert(res.statusText);
        });
      }
    const handleClickTab=(type)=>{
      console.log(type);
      setClickTab(true);
    }
    function AddLessonBasic(basicInput)
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        setMyObject({
            ...myObject,
            title: basicInput.title,
            content: basicInput.content,
            sectionId: 1,                                                                                                    
        });
    }

    function AddLessonVideo(videoInput)
    {
        console.log(videoInput);
        console.log("videoInput");
        setMyObject({
            ...myObject,
            imageUrl: videoInput.imageUrl,
            videoUrl: videoInput.videoUrl
        });

    }
    function AddLessonAttachments(attachmentInput)
    {
        setMyObject({
            ...myObject,
            attachments: [{attachmentUrl: attachmentInput.attachmentUrl, size: 0,
                isDelete: false}],
        });
    }
  return (
      <>
      <div>
        <div className="modal-dialog modal-lg">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title" id="lectureModalLabel">
                Add Lecture
              </h5>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
              <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">×</span>
              </button>
            </div>
            <div className="modal-body">
              <div className="new-section-block">
                <div className="row">
                  <div className="col-md-12">
                    <div className="course-main-tabs">
                      <div
                        className="nav nav-pills flex-column flex-sm-row nav-tabs"
                        role="tablist"
                      >
                        <Tabs handleClickTab={handleClickTab}></Tabs>
                      </div>
                      <div className="tab-content">
                        <Switch>
                            <Route path="/addlesson" exact>
                                <Basic onAddLessonBasic={AddLessonBasic} myObject = {myObject}></Basic>
                            </Route>
                            <Route path="/addlesson/video" exact>
                                <Video onAddLessonVideo={AddLessonVideo} myObject = {myObject}></Video>
                            </Route>
                            <Route
                            path="/addlesson/attachments" exact>
                                <Attachments onAddLessonAttachments={AddLessonAttachments}></Attachments>
                            </Route>
                        </Switch>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <Footer hanldeClickButtonAddLesson={hanldeClickButtonAddLesson} myObject={myObject}></Footer>
          </div>
        </div>
      </div>
      </>
  );
}
export default AddLesson;
