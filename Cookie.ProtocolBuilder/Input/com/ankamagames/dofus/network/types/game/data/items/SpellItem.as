package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class SpellItem extends Item implements INetworkType
   {
      
      public static const protocolId:uint = 49;
       
      
      public var spellId:int = 0;
      
      public var spellLevel:int = 0;
      
      public function SpellItem()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 49;
      }
      
      public function initSpellItem(param1:int = 0, param2:int = 0) : SpellItem
      {
         this.spellId = param1;
         this.spellLevel = param2;
         return this;
      }
      
      override public function reset() : void
      {
         this.spellId = 0;
         this.spellLevel = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_SpellItem(param1);
      }
      
      public function serializeAs_SpellItem(param1:ICustomDataOutput) : void
      {
         super.serializeAs_Item(param1);
         param1.writeInt(this.spellId);
         if(this.spellLevel < 1 || this.spellLevel > 200)
         {
            throw new Error("Forbidden value (" + this.spellLevel + ") on element spellLevel.");
         }
         param1.writeShort(this.spellLevel);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SpellItem(param1);
      }
      
      public function deserializeAs_SpellItem(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._spellIdFunc(param1);
         this._spellLevelFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SpellItem(param1);
      }
      
      public function deserializeAsyncAs_SpellItem(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._spellIdFunc);
         param1.addChild(this._spellLevelFunc);
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         this.spellId = param1.readInt();
      }
      
      private function _spellLevelFunc(param1:ICustomDataInput) : void
      {
         this.spellLevel = param1.readShort();
         if(this.spellLevel < 1 || this.spellLevel > 200)
         {
            throw new Error("Forbidden value (" + this.spellLevel + ") on element of SpellItem.spellLevel.");
         }
      }
   }
}
