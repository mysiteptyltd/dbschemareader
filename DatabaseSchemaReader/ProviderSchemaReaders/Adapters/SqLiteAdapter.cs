﻿using System.Collections.Generic;
using DatabaseSchemaReader.DataSchema;
using DatabaseSchemaReader.ProviderSchemaReaders.Databases.SQLite;

namespace DatabaseSchemaReader.ProviderSchemaReaders.Adapters
{
    class SqLiteAdapter : ReaderAdapter
    {
        public SqLiteAdapter(SchemaParameters schemaParameters) : base(schemaParameters)
        {
        }
        public override IList<DataType> DataTypes()
        {
            return new DataTypeList().Execute();
        }

        public override IList<DatabaseTable> Tables(string tableName)
        {
            return new Tables(tableName)
                .Execute(DbConnection, DbTransaction);
        }

        public override IList<DatabaseColumn> Columns(string tableName)
        {
            return new Columns( tableName)
                .Execute(DbConnection, DbTransaction);
        }


        public override IList<DatabaseIndex> Indexes(string tableName)
        {
            return new Indexes( tableName)
                .Execute(DbConnection, DbTransaction);
        }

        public override IList<DatabaseConstraint> ForeignKeys(string tableName)
        {
            return new Constraints(tableName)
                .Execute(DbConnection, DbTransaction);
        }

        public override IList<DatabaseTrigger> Triggers(string tableName)
        {
            return new Triggers( tableName)
                .Execute(DbConnection, DbTransaction);
        }


        public override IList<DatabaseView> Views(string viewName)
        {
            return new Views(viewName)
               .Execute(DbConnection, DbTransaction);
        }

        public override IList<DatabaseColumn> ViewColumns(string viewName)
        {
            return new ViewColumns(viewName)
                .Execute(DbConnection, DbTransaction);
        }
    }
}