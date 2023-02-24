import React from 'react';
import PropTypes from 'prop-types';
import ListBlog from './ListBlog';
import FormSearch from './FormSearch';
import Title from './Title';

Blog.propTypes = {};

function Blog(props) {
  return (
    <>
      <Title />
      <div class="_205ef5">
        <div class="container">
          <div class="row">
            <FormSearch />
            <ListBlog />
          </div>
        </div>
      </div>
    </>
  );
}

export default Blog;
