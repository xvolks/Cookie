package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.dofus.network.types.game.paddock.PaddockItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameDataPaddockObjectListAddMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5992;
       
      
      private var _isInitialized:Boolean = false;
      
      public var paddockItemDescription:Vector.<PaddockItem>;
      
      private var _paddockItemDescriptiontree:FuncTree;
      
      public function GameDataPaddockObjectListAddMessage()
      {
         this.paddockItemDescription = new Vector.<PaddockItem>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5992;
      }
      
      public function initGameDataPaddockObjectListAddMessage(param1:Vector.<PaddockItem> = null) : GameDataPaddockObjectListAddMessage
      {
         this.paddockItemDescription = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.paddockItemDescription = new Vector.<PaddockItem>();
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
         this.serializeAs_GameDataPaddockObjectListAddMessage(param1);
      }
      
      public function serializeAs_GameDataPaddockObjectListAddMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.paddockItemDescription.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.paddockItemDescription.length)
         {
            (this.paddockItemDescription[_loc2_] as PaddockItem).serializeAs_PaddockItem(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameDataPaddockObjectListAddMessage(param1);
      }
      
      public function deserializeAs_GameDataPaddockObjectListAddMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:PaddockItem = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new PaddockItem();
            _loc4_.deserialize(param1);
            this.paddockItemDescription.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameDataPaddockObjectListAddMessage(param1);
      }
      
      public function deserializeAsyncAs_GameDataPaddockObjectListAddMessage(param1:FuncTree) : void
      {
         this._paddockItemDescriptiontree = param1.addChild(this._paddockItemDescriptiontreeFunc);
      }
      
      private function _paddockItemDescriptiontreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._paddockItemDescriptiontree.addChild(this._paddockItemDescriptionFunc);
            _loc3_++;
         }
      }
      
      private function _paddockItemDescriptionFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PaddockItem = new PaddockItem();
         _loc2_.deserialize(param1);
         this.paddockItemDescription.push(_loc2_);
      }
   }
}
