import React from 'react';
import PropTypes from 'prop-types';

ShoppingCartIcon.propTypes = {

};

function ShoppingCartIcon (props) {
  return (
    <>
        <li>
            <a href="shopping_cart.html" className="option_links" title="cart">
                <i className="uil uil-shopping-cart-alt" />
                <span className="noti_count">2</span>
            </a>
        </li>
    </>
  );
}

export default ShoppingCartIcon;