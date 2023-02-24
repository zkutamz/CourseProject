import React from 'react';
import PropTypes from 'prop-types';

ListBlog.propTypes = {};

function ListBlog(props) {
  return (
    <div className="col-lg-9 col-md-7">
      <div className="blogbg_1 mt-50">
        <a href="blog_single_view.html" className="hf_img">
          <img src="images/blog/img-1.jpg" alt="" />
          <div className="course-overlay" />
        </a>
        <div className="hs_content">
          <div className="vdtodt">
            <span className="vdt14">109k views</span>
            <span className="vdt14">March 10, 2020</span>
          </div>
          <a href="blog_single_view.html" className="crse14s title900">
            Blog Title Here
          </a>
          <p className="blog_des">
            Donec eget arcu vel mauris lacinia vestibulum id eu elit. Nam metus odio, iaculis eu
            nunc et, interdum mollis arcu. Pellentesque viverra faucibus diam. In sit amet laoreet
            dolor, vitae fringilla quam interdum mollis arcu.
          </p>
          <a href="blog_single_view.html" className="view-blog-link">
            Read More
            <i className="uil uil-arrow-right" />
          </a>
        </div>
      </div>
      <div className="blogbg_1 mt-30">
        <a href="blog_single_view.html" className="hf_img">
          <img src="images/blog/img-2.jpg" alt="" />
          <div className="course-overlay" />
        </a>
        <div className="hs_content">
          <div className="vdtodt">
            <span className="vdt14">109k views</span>
            <span className="vdt14">March 10, 2020</span>
          </div>
          <a href="blog_single_view.html" className="crse14s title900">
            Blog Title Here
          </a>
          <p className="blog_des">
            Donec eget arcu vel mauris lacinia vestibulum id eu elit. Nam metus odio, iaculis eu
            nunc et, interdum mollis arcu. Pellentesque viverra faucibus diam. In sit amet laoreet
            dolor interdum mollis arcu interdum mollis arcu.
          </p>
          <a href="blog_single_view.html" className="view-blog-link">
            Read More
            <i className="uil uil-arrow-right" />
          </a>
        </div>
      </div>
      <div className="blogbg_1 mt-30">
        <a href="blog_single_view.html" className="hf_img">
          <img src="images/blog/img-3.jpg" alt="" />
          <div className="course-overlay" />
        </a>
        <div className="hs_content">
          <div className="vdtodt">
            <span className="vdt14">109k views</span>
            <span className="vdt14">March 10, 2020</span>
          </div>
          <a href="blog_single_view.html" className="crse14s title900">
            Blog Title Here
          </a>
          <p className="blog_des">
            Donec eget arcu vel mauris lacinia vestibulum id eu elit. Nam metus odio, iaculis eu
            nunc et, interdum mollis arcu. Pellentesque viverra faucibus diam. In sit amet laoreet
            dolor interdum mollis arcu.
          </p>
          <a href="blog_single_view.html" className="view-blog-link">
            Read More
            <i className="uil uil-arrow-right" />
          </a>
        </div>
      </div>
      <div className="blogbg_1 mt-30">
        <a href="blog_single_view.html" className="hf_img">
          <img src="images/blog/img-4.jpg" alt="" />
          <div className="course-overlay" />
        </a>
        <div className="hs_content">
          <div className="vdtodt">
            <span className="vdt14">109k views</span>
            <span className="vdt14">March 10, 2020</span>
          </div>
          <a href="blog_single_view.html" className="crse14s title900">
            Blog Title Here
          </a>
          <p className="blog_des">
            Donec eget arcu vel mauris lacinia vestibulum id eu elit. Nam metus odio, iaculis eu
            nunc et, interdum mollis arcu. Pellentesque viverra faucibus diam. In sit amet laoreet
            dolor interdum mollis arcu.
          </p>
          <a href="blog_single_view.html" className="view-blog-link">
            Read More
            <i className="uil uil-arrow-right" />
          </a>
        </div>
      </div>
      <div className="main-p-pagination">
        <nav aria-label="Page navigation example">
          <ul className="pagination">
            <li className="page-item disabled">
              <a className="page-link" href="#" aria-label="Previous">
                PREV
              </a>
            </li>
            <li className="page-item">
              <a className="page-link active" href="#">
                1
              </a>
            </li>
            <li className="page-item">
              <a className="page-link" href="#">
                2
              </a>
            </li>
            <li className="page-item">
              <a className="page-link" href="#">
                ...
              </a>
            </li>
            <li className="page-item">
              <a className="page-link" href="#">
                24
              </a>
            </li>
            <li className="page-item">
              <a className="page-link" href="#" aria-label="Next">
                NEXT
              </a>
            </li>
          </ul>
        </nav>
      </div>
    </div>
  );
}

export default ListBlog;
