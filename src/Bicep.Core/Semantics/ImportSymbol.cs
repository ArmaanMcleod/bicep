// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using Bicep.Core.Extensions;
using Bicep.Core.Syntax;

namespace Bicep.Core.Semantics
{
    public class ImportSymbol : DeclaredSymbol
    {
        public ImportSymbol(ISymbolContext context, string name, ImportDeclarationSyntax declaringSyntax)
            : base(context, name, declaringSyntax, declaringSyntax.Name)
        {
        }

        public ImportDeclarationSyntax DeclaringImport => (ImportDeclarationSyntax)this.DeclaringSyntax;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitImportSymbol(this);
        }

        public override SymbolKind Kind => SymbolKind.Import;

        public override IEnumerable<Symbol> Descendants => this.Type.AsEnumerable();
    }
}