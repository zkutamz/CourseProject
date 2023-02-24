import React, { useEffect, useState } from 'react';
import instructorAPI from '../../../api/instructorAPI';
import profileAPI from '../../../api/profileAPI';

function UserProfile()
{
    const [profile,setProfile] = useState([]);
    const [totalStudentEnrolled,setTotalStudentEnrolled] = useState([]);
    const [totalCourse,setTotalCourse]= useState([]);
    useEffect(()=>{
        async function fetchDataProfile()
        {
            try
            {
                var response = await profileAPI.getUserInformation(3);
                const data = response.data;
                setProfile(data);
            }
            catch(error)
            {
                console.log('Fail to fetch data get profile', error.message);
            }
        }
        async function fetchDataTotalStudentEnrolled()
        {
          try{
            var response = await instructorAPI.GetTotalEnrollStudentsOfAnInstructor(3);
            const data = response.data;
            setTotalStudentEnrolled(data);
          }
          catch(error)
          {
            console.log('Fail to get data GetTotalEnrollStudentsOfAnInstructor', error.message);
          }
            
        }
        async function fetchDataTotalCourseOfInstructor()
        {
            var response = await instructorAPI.GetTotalCourseOfAnInstructor(3);
            const data = response.data;
            setTotalCourse(data);
        }
        fetchDataProfile();
        fetchDataTotalStudentEnrolled();
        fetchDataTotalCourseOfInstructor();
    },[]);

    return (
        <div class="fcrse_2 mb-30">
                  <div class="tutor_img">
                    <a href="my_instructor_profile_view.html"
                      ><img src={profile.profileImageUrl} alt=""
                    /></a>
                  </div>
                  <div class="tutor_content_dt">
                    <div class="tutor150">
                      <a
                        href="my_instructor_profile_view.html"
                        class="tutor_name"
                        >{profile.firstName} {profile.lastName}</a
                      >
                      <div class="mef78" title="Verify">
                        <i class="uil uil-check-circle"></i>
                      </div>
                    </div>
                    <div class="tutor_cate">
                      {profile.intro}
                    </div>
                    <ul class="tutor_social_links">
                      <li>
                        <a href={profile.facebookLink} class="fb"
                          ><i class="fab fa-facebook-f"></i
                        ></a>
                      </li>
                      <li>
                        <a href={profile.twitterLink} class="tw"
                          ><i class="fab fa-twitter"></i
                        ></a>
                      </li>
                      <li>
                        <a href={profile.linkedInLink} class="ln"
                          ><i class="fab fa-linkedin-in"></i
                        ></a>
                      </li>
                      <li>
                        <a href={profile.youtubeLink} class="yu"
                          ><i class="fab fa-youtube"></i
                        ></a>
                      </li>
                    </ul>
                    <div class="tut1250">
                      <span class="vdt15">{totalStudentEnrolled} Students</span>
                      <span class="vdt15">{totalCourse} Courses</span>
                    </div>
                    <a
                      href="my_instructor_profile_view.html"
                      class="prfle12link"
                      >Go To Profile</a
                    >
                  </div>
                </div>
    );
}
export default UserProfile;