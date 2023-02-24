import React, { useEffect, useState } from 'react'
import { Link, NavLink } from 'react-router-dom';
import certificateAPI from '../../api/certificateAPI';
import CertificateHeader from '../../components/CertificateHeader'
export default function CertificateCenter() {

  const [certificateCategories, setCertificateCategories] = useState([]);
  const [findResult, setFindResult] = useState([]);
  const [keyword, setKeyword] = useState('');
  const [isFind, setIsFind] = useState(false);
  const [categoryId, setCategoryId] = useState(1);
  const [certificates, setCertificates] = useState([])
  const [isFirstLoading, setIsFirstLoading] = useState(true);
  const [active, setActive] = useState('active')
  function handleInputChange(e) {
    setKeyword(e.target.value);
  }
  function handleFindCertificate() {
    setIsFind(!isFind);
  }
  async function getCertificateCategory() {
    await certificateAPI.getAllCertificateCategory()
      .then(response => { setCertificateCategories(response.data.objects) })
      .catch(error => console.log(error))
  }


  function handleCategoryClick(categoryId) {
    setCategoryId(categoryId);
    setIsFirstLoading(false);
  }
  useEffect(async () => {
    if (keyword != '') {
      await certificateAPI.getCertificates(keyword)
        .then(response => {
          setFindResult(response.data)
        })
        .catch(error => {
          console.log(error);
        })

    } else {
      setFindResult([]);
    }
  }, [isFind])

  useEffect(async () => {
    await certificateAPI.filterCertificateByCategory(categoryId)
      .then(response => {
        setCertificates(response.data);
      })
      .catch(error => {
        console.log(error)
      })
  }, [categoryId])

  useEffect(async () => {
    getCertificateCategory();
  }, [])

  return (
    <>

      <CertificateHeader />

      <div class="wrapper _bg4586 _new89">
        <div class="_215certibg">
          <div class="container">
            <div class="row">
              <div class="col-lg-12">
                <div class="cert_banner_text">
                  <h1>Certification Center</h1>
                  <p>For Students and Instructors</p>
                  <ul class="certi_icons">
                    <li><a href="#" class="edttslogo"><img src="images/logo1.svg" alt="" /></a></li>
                    <li><div class="edttsplus"><img src="images/cerificate_center/plus.svg" alt="" /></div></li>
                    <li><a href="#" class="edttslogo1"><img src="images/cerificate_center/certicon.svg" alt="" /></a></li>
                  </ul>
                  <button class="certi-btn" onclick="window.location.href = 'certification_start_form.html';"><Link class="certi-btn" to="/certificate_center/certification_start_form">Start Certification</Link></button>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="_215xd5">
          <div class="container">
            <div class="row">
              <div class="col-lg-12">
                <div class="title889">
                  <h2>Find Certificate</h2>
                </div>
              </div>
              <div class="col-lg-6 col-md-6">
                <div class="ui search focus mt-30">
                  <div class="ui left icon input swdh11 swdh19">
                    <input onChange={handleInputChange} class="prompt srch_explore" type="text" name="fullname" id="id_fullname" placeholder="Full Name" />
                  </div>
                </div>
              </div>
              <div class="col-lg-3 col-md-6">
                <button type='button' class="login-btn" onClick={handleFindCertificate}>Find Certificate</button>
              </div>
            </div>
          </div>
          <div class="tab-content" id="pills-tabContent">
            <div class="tab-pane fade show active" id="pills-development" role="tabpanel" aria-labelledby="pills-development-tab">
              <div class="certicates">
                <div class="row">
                  {
                    findResult ? findResult.map(certificate => (
                      <div class="col-md-3 col-sm-6" key={certificate.id}>
                        <Link to="#" class="certilink__152">
                          {certificate.certificateName}
                        </Link>
                      </div>
                    )) : <></>
                  }
                </div>
              </div>
            </div>
          </div>
          <div class="_215td5">
            <div class="container">
              <div class="row">
                <div class="col-lg-12">
                  <div class="title589">
                    <h2>Our Certification</h2>
                    <p>We prepared tests for the most popular categories and get cerificate</p>
                  </div>
                </div>
                <div class="col-lg-12">
                  <div class="catey-tabs">
                    <ul class="nav nav-pills justify-content-center mb-3" id="pills-tab" role="tablist">
                      {
                        certificateCategories ? certificateCategories.map(category => (
                          <li class="nav-item" key={category.id}>
                            <NavLink
                              aria-selected="false"
                              onClick={() => handleCategoryClick(category.id)}
                              to="#"
                              class={`nav-link ${isFirstLoading && category.id == 1 ? "active" : ""}`}
                              id="pills-development-tab" data-toggle="pill"
                              href="#pills-development"
                              role="tab"
                              aria-controls="pills-development"
                              aria-selected="true">{category.certificateCatgoryName}</NavLink>
                          </li>
                        )) : <></>
                      }
                    </ul>
                    <div class="tab-content" id="pills-tabContent">
                      <div class="tab-pane fade show active" id="pills-development" role="tabpanel" aria-labelledby="pills-development-tab">
                        <div class="certicates">
                          <div class="row">
                            {
                              certificates.map(certificate => (
                                <div class="col-md-3 col-sm-6">
                                  <Link to="#" class="certilink__152">
                                    {certificate.certificateName}
                                  </Link>
                                </div>
                              ))
                            }

                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="_485td5">
            <div class="container">
              <div class="row justify-content-lg-center justify-content-md-center">
                <div class="col-lg-12">
                  <div class="titleceti89">
                    <h2>Who Can Get Benefit From This?</h2>
                  </div>
                </div>
                <div class="col-lg-3 col-md-5 col-sm-6">
                  <div class="who_get">
                    <div class="who_img">
                      <img src="images/cerificate_center/student.svg" alt="" />
                    </div>
                    <h4>Students</h4>
                  </div>
                </div>
                <div class="col-lg-3 col-md-5 col-sm-6">
                  <div class="who_get">
                    <div class="who_img">
                      <img src="images/cerificate_center/instructor.svg" alt="" />
                    </div>
                    <h4>Instructor</h4>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="_215td5">
            <div class="container">
              <div class="row justify-content-md-center">
                <div class="col-lg-12">
                  <div class="title589">
                    <h2>What Will You Get?</h2>
                    <p>Cursus company, which confirms your skills and knowledge of Certification</p>
                  </div>
                </div>
                <div class="col-md-12">
                  <div class="knowledge_dts">
                    <p>Morbi eget elit eget turpis varius mollis eget vel massa. Donec porttitor, sapien eget commodo vulputate, erat felis aliquam dolor, non condimentum libero dolor vel ipsum. Sed porttitor nisi eget nulla ullamcorper eleifend. Fusce tristique sapien nisi, vel feugiat neque luctus sit amet. Quisque consequat quis turpis in mattis. Maecenas eget mollis nisl. Cras porta dapibus est, quis malesuada ex iaculis at. Vestibulum egestas tortor in urna tempor, in fermentum lectus bibendum. In leo leo, bibendum at pharetra at, tincidunt in nulla. In vel malesuada nulla, sed tincidunt neque. Phasellus at massa vel sem aliquet sodales non in magna. Ut tempus ipsum sagittis neque cursus euismod. Vivamus luctus elementum tortor, ac aliquet dolor vehicula et. Nulla vehicula pharetra lacus ornare gravida. Vivamus mollis ullamcorper dui quis gravida. Aenean pulvinar pulvinar arcu a suscipit.</p>
                    <button class="knowledge_btn" onclick="window.location.href = '#';">Knowledge Base</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  )
}
