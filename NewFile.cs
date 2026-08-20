var user = await _context.Users
    .FirstOrDefaultAsync(x => x.UserId.ToString() == userId);