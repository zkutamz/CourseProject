import React, { useRef, useState } from 'react'
import PropTypes from 'prop-types'

SearchReview.propTypes = {
  onSubmit: PropTypes.func,
}
SearchReview.defaultProps = {
  onSubmit: null,
}
function SearchReview(props) {
  const { onSubmit } = props
  const [searchTerm, setSearchTerm] = useState('')
  const typingTimeoutRef = useRef(null)

  function handleSearchTermChange(e) {
    const value = e.target.value
    setSearchTerm(value)

    if (!onSubmit) return

    if (typingTimeoutRef.current) {
      clearTimeout(typingTimeoutRef.current)
    }

    //settimeout để push value lên api tìm kiếm
    typingTimeoutRef.current = setTimeout(() => {
      const formValues = {
        searchTerm: value,
      }
      onSubmit(formValues)
    }, 900)
  }

  return (
    <div className="review_search">
      <input
        className="rv_srch"
        value={searchTerm}
        onChange={handleSearchTermChange}
        type="text"
        placeholder="Search courses..."
      />
    </div>
  )
}

export default SearchReview
