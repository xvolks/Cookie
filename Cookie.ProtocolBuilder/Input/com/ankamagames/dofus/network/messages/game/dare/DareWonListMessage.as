package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareWonListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6682;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dareId:Vector.<Number>;
      
      private var _dareIdtree:FuncTree;
      
      public function DareWonListMessage()
      {
         this.dareId = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6682;
      }
      
      public function initDareWonListMessage(param1:Vector.<Number> = null) : DareWonListMessage
      {
         this.dareId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dareId = new Vector.<Number>();
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
         this.serializeAs_DareWonListMessage(param1);
      }
      
      public function serializeAs_DareWonListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.dareId.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.dareId.length)
         {
            if(this.dareId[_loc2_] < 0 || this.dareId[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.dareId[_loc2_] + ") on element 1 (starting at 1) of dareId.");
            }
            param1.writeDouble(this.dareId[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareWonListMessage(param1);
      }
      
      public function deserializeAs_DareWonListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:Number = NaN;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readDouble();
            if(_loc4_ < 0 || _loc4_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of dareId.");
            }
            this.dareId.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareWonListMessage(param1);
      }
      
      public function deserializeAsyncAs_DareWonListMessage(param1:FuncTree) : void
      {
         this._dareIdtree = param1.addChild(this._dareIdtreeFunc);
      }
      
      private function _dareIdtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._dareIdtree.addChild(this._dareIdFunc);
            _loc3_++;
         }
      }
      
      private function _dareIdFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readDouble();
         if(_loc2_ < 0 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of dareId.");
         }
         this.dareId.push(_loc2_);
      }
   }
}
