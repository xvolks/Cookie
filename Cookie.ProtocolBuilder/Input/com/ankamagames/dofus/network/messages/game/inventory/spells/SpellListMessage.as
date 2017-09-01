package com.ankamagames.dofus.network.messages.game.inventory.spells
{
   import com.ankamagames.dofus.network.types.game.data.items.SpellItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SpellListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1200;
       
      
      private var _isInitialized:Boolean = false;
      
      public var spellPrevisualization:Boolean = false;
      
      public var spells:Vector.<SpellItem>;
      
      private var _spellstree:FuncTree;
      
      public function SpellListMessage()
      {
         this.spells = new Vector.<SpellItem>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1200;
      }
      
      public function initSpellListMessage(param1:Boolean = false, param2:Vector.<SpellItem> = null) : SpellListMessage
      {
         this.spellPrevisualization = param1;
         this.spells = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.spellPrevisualization = false;
         this.spells = new Vector.<SpellItem>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_SpellListMessage(param1);
      }
      
      public function serializeAs_SpellListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.spellPrevisualization);
         param1.writeShort(this.spells.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.spells.length)
         {
            (this.spells[_loc2_] as SpellItem).serializeAs_SpellItem(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SpellListMessage(param1);
      }
      
      public function deserializeAs_SpellListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:SpellItem = null;
         this._spellPrevisualizationFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new SpellItem();
            _loc4_.deserialize(param1);
            this.spells.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SpellListMessage(param1);
      }
      
      public function deserializeAsyncAs_SpellListMessage(param1:FuncTree) : void
      {
         param1.addChild(this._spellPrevisualizationFunc);
         this._spellstree = param1.addChild(this._spellstreeFunc);
      }
      
      private function _spellPrevisualizationFunc(param1:ICustomDataInput) : void
      {
         this.spellPrevisualization = param1.readBoolean();
      }
      
      private function _spellstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._spellstree.addChild(this._spellsFunc);
            _loc3_++;
         }
      }
      
      private function _spellsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:SpellItem = new SpellItem();
         _loc2_.deserialize(param1);
         this.spells.push(_loc2_);
      }
   }
}
