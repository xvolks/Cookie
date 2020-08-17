package com.ankamagames.dofus.network.messages.game.idol
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.idol.Idol;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdolFightPreparationUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6586;
       
      
      private var _isInitialized:Boolean = false;
      
      public var idolSource:uint = 0;
      
      public var idols:Vector.<Idol>;
      
      private var _idolstree:FuncTree;
      
      public function IdolFightPreparationUpdateMessage()
      {
         this.idols = new Vector.<Idol>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6586;
      }
      
      public function initIdolFightPreparationUpdateMessage(param1:uint = 0, param2:Vector.<Idol> = null) : IdolFightPreparationUpdateMessage
      {
         this.idolSource = param1;
         this.idols = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.idolSource = 0;
         this.idols = new Vector.<Idol>();
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
         this.serializeAs_IdolFightPreparationUpdateMessage(param1);
      }
      
      public function serializeAs_IdolFightPreparationUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.idolSource);
         param1.writeShort(this.idols.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.idols.length)
         {
            param1.writeShort((this.idols[_loc2_] as Idol).getTypeId());
            (this.idols[_loc2_] as Idol).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdolFightPreparationUpdateMessage(param1);
      }
      
      public function deserializeAs_IdolFightPreparationUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:Idol = null;
         this._idolSourceFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(Idol,_loc4_);
            _loc5_.deserialize(param1);
            this.idols.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdolFightPreparationUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_IdolFightPreparationUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idolSourceFunc);
         this._idolstree = param1.addChild(this._idolstreeFunc);
      }
      
      private function _idolSourceFunc(param1:ICustomDataInput) : void
      {
         this.idolSource = param1.readByte();
         if(this.idolSource < 0)
         {
            throw new Error("Forbidden value (" + this.idolSource + ") on element of IdolFightPreparationUpdateMessage.idolSource.");
         }
      }
      
      private function _idolstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._idolstree.addChild(this._idolsFunc);
            _loc3_++;
         }
      }
      
      private function _idolsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:Idol = ProtocolTypeManager.getInstance(Idol,_loc2_);
         _loc3_.deserialize(param1);
         this.idols.push(_loc3_);
      }
   }
}
