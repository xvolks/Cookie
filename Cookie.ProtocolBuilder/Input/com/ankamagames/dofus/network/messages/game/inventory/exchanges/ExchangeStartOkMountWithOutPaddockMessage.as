package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.mount.MountClientData;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeStartOkMountWithOutPaddockMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5991;
       
      
      private var _isInitialized:Boolean = false;
      
      public var stabledMountsDescription:Vector.<MountClientData>;
      
      private var _stabledMountsDescriptiontree:FuncTree;
      
      public function ExchangeStartOkMountWithOutPaddockMessage()
      {
         this.stabledMountsDescription = new Vector.<MountClientData>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5991;
      }
      
      public function initExchangeStartOkMountWithOutPaddockMessage(param1:Vector.<MountClientData> = null) : ExchangeStartOkMountWithOutPaddockMessage
      {
         this.stabledMountsDescription = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.stabledMountsDescription = new Vector.<MountClientData>();
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
         this.serializeAs_ExchangeStartOkMountWithOutPaddockMessage(param1);
      }
      
      public function serializeAs_ExchangeStartOkMountWithOutPaddockMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.stabledMountsDescription.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.stabledMountsDescription.length)
         {
            (this.stabledMountsDescription[_loc2_] as MountClientData).serializeAs_MountClientData(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartOkMountWithOutPaddockMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartOkMountWithOutPaddockMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:MountClientData = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new MountClientData();
            _loc4_.deserialize(param1);
            this.stabledMountsDescription.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartOkMountWithOutPaddockMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartOkMountWithOutPaddockMessage(param1:FuncTree) : void
      {
         this._stabledMountsDescriptiontree = param1.addChild(this._stabledMountsDescriptiontreeFunc);
      }
      
      private function _stabledMountsDescriptiontreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._stabledMountsDescriptiontree.addChild(this._stabledMountsDescriptionFunc);
            _loc3_++;
         }
      }
      
      private function _stabledMountsDescriptionFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:MountClientData = new MountClientData();
         _loc2_.deserialize(param1);
         this.stabledMountsDescription.push(_loc2_);
      }
   }
}
