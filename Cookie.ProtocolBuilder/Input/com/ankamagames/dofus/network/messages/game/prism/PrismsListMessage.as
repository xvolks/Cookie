package com.ankamagames.dofus.network.messages.game.prism
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.prism.PrismSubareaEmptyInfo;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PrismsListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6440;
       
      
      private var _isInitialized:Boolean = false;
      
      public var prisms:Vector.<PrismSubareaEmptyInfo>;
      
      private var _prismstree:FuncTree;
      
      public function PrismsListMessage()
      {
         this.prisms = new Vector.<PrismSubareaEmptyInfo>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6440;
      }
      
      public function initPrismsListMessage(param1:Vector.<PrismSubareaEmptyInfo> = null) : PrismsListMessage
      {
         this.prisms = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.prisms = new Vector.<PrismSubareaEmptyInfo>();
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
         this.serializeAs_PrismsListMessage(param1);
      }
      
      public function serializeAs_PrismsListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.prisms.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.prisms.length)
         {
            param1.writeShort((this.prisms[_loc2_] as PrismSubareaEmptyInfo).getTypeId());
            (this.prisms[_loc2_] as PrismSubareaEmptyInfo).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismsListMessage(param1);
      }
      
      public function deserializeAs_PrismsListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:PrismSubareaEmptyInfo = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(PrismSubareaEmptyInfo,_loc4_);
            _loc5_.deserialize(param1);
            this.prisms.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismsListMessage(param1);
      }
      
      public function deserializeAsyncAs_PrismsListMessage(param1:FuncTree) : void
      {
         this._prismstree = param1.addChild(this._prismstreeFunc);
      }
      
      private function _prismstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._prismstree.addChild(this._prismsFunc);
            _loc3_++;
         }
      }
      
      private function _prismsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:PrismSubareaEmptyInfo = ProtocolTypeManager.getInstance(PrismSubareaEmptyInfo,_loc2_);
         _loc3_.deserialize(param1);
         this.prisms.push(_loc3_);
      }
   }
}
