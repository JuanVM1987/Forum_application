namespace HttpClients.Implementation.CreateQuery;

public class ConstructQuery
{
    public static string ConstructQueryMethod(int? postId,string? owner,  string? title, DateTime? createdDate)
    {
        
        string query = "";
        if (postId!=null)
        {
            query += $"?postId={postId}";
        }

        if (!string.IsNullOrEmpty(owner))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"owner={owner}";
        }

        if (title != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"title={title}";
        }

        if (createdDate!=null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"created={createdDate}";
        }

        return query;
    }
    
}