import React from 'react';
import CategoryList from '../CategoryList';

CategorySideBar.propTypes = {

};

function CategorySideBar (props) {
    let toggle = false;
    function clicked(e) {
        toggle = !toggle;
        if(toggle){
            document.getElementById("content-cate-list").style.display = 'block';
        }else {
            document.getElementById("content-cate-list").style.display = 'none';
        }
    }

    return (
        <>
            <label onClick={clicked} className="menu--link" title="Categories">
                <i className="uil uil-layers menu--icon" />
                <span className="menu--label">Categories</span>
            </label>
            <ul className="sub_menu" id="content-cate-list">
                <CategoryList />
            </ul>
        </>
    );
}
export default CategorySideBar;