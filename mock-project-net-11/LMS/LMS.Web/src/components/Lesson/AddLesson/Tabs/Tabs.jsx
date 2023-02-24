import React from 'react';
import { NavLink } from 'react-router-dom';
function Tabs({handleClickTab}) {
  const handleClickTabVideo=()=>{
    handleClickTab("video");
  }
  return (
    <>
    <NavLink
          to="/addlesson"
          exact
          className="flex-sm-fill text-sm-center nav-link"
          data-toggle="tab"
          role="tab"
          aria-selected="false"
        >
          <i className="fas fa-file-alt mr-2" />
          Basic
        </NavLink>
            <NavLink
          to="/addlesson/video"
          exact
          className="flex-sm-fill text-sm-center nav-link"
          data-toggle="tab"
          role="tab"
          aria-selected="false"
          onClick={handleClickTabVideo}
        >
          <i className="fas fa-video mr-2" />
          video
        </NavLink>
            <NavLink
          to="/addlesson/attachments"
          exact
          className="flex-sm-fill text-sm-center nav-link"
          data-toggle="tab"
          role="tab"
          aria-selected="false"
        >
          <i class="fas fa-paperclip mr-2"></i>
          attachments
        </NavLink>
    </>
  );
}
export default Tabs;
